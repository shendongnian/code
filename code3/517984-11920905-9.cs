    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Collections.Concurrent;
    using System.Threading.Tasks;
    using System.IO;
    using System.Data;
    namespace dataTableTesting2
    {
        class Program
        {
            private static IEnumerable<string> fileName = new List<string>() { "hi", "bye" };
            private static const int BufferSize = 20; //Each buffer can only contain this many elements at a time
                                                      //This limits the total amount of memory 
            private static const int MaxBlockSize = 100;
            private static BlockingCollection<string> buffer1 = new BlockingCollection<string>(BufferSize);
            private static BlockingCollection<string[]> buffer2 = new BlockingCollection<string[]>(BufferSize);
            private static BlockingCollection<Object[][]> buffer3 = new BlockingCollection<Object[][]>(BufferSize);
            /// <summary>
            /// Start Pipelines and wait for them to finish.
            /// </summary>
            static void Main(string[] args)
            {
                TaskFactory f = new TaskFactory(TaskCreationOptions.LongRunning, TaskContinuationOptions.None);
                Task stage0 = f.StartNew(() => PopulateFilesList(buffer1));
                Task stage1 = f.StartNew(() => ReadFiles(buffer1, buffer2));
                Task stage2 = f.StartNew(() => ParseStringBlocks(buffer2, buffer3));
                Task stage3 = f.StartNew(() => UploadBlocks(buffer3) );
                Task.WaitAll(stage0, stage1, stage2, stage3);
                /*
                // Note for more workers on particular stages you can make more tasks for each stage, like the following
                //    which populates the file list in 1 task, reads the files into string[] blocks in 1 task,
                //    then parses the string[] blocks in 4 concurrent tasks
                //    and lastly uploads the info in 2 tasks
             
                TaskFactory f = new TaskFactory(TaskCreationOptions.LongRunning, TaskContinuationOptions.None);
                Task stage0 = f.StartNew(() => PopulateFilesList(buffer1));
                Task stage1 = f.StartNew(() => ReadFiles(buffer1, buffer2));
             
                Task stage2a = f.StartNew(() => ParseStringBlocks(buffer2, buffer3));
                Task stage2b = f.StartNew(() => ParseStringBlocks(buffer2, buffer3));
                Task stage2c = f.StartNew(() => ParseStringBlocks(buffer2, buffer3));
                Task stage2d = f.StartNew(() => ParseStringBlocks(buffer2, buffer3));
            
                Task stage3a = f.StartNew(() => UploadBlocks(buffer3) );
                Task stage3b = f.StartNew(() => UploadBlocks(buffer3) );
            
                Task.WaitAll(stage0, stage1, stage2a, stage2b, stage2c, stage2d, stage3a, stage3b);
                          
                */
            }
            /// <summary>
            /// Adds the filenames to process into the first pipeline
            /// </summary>
            /// <param name="output"></param>
            private static void PopulateFilesList( BlockingCollection<string> output )
            {
                try
                {
                    buffer1.Add("file1.txt");
                    buffer1.Add("file2.txt");
                    //...
                    buffer1.Add("lastFile.txt");
                }
                finally
                {
                    output.CompleteAdding();
                }
            }
            /// <summary>
            /// Takes filnames out of the first pipeline, reads them into string[] blocks, and puts them in the second pipeline
            /// </summary>
            private static void ReadFiles( BlockingCollection<string> input, BlockingCollection<string[]> output)
            {
                try
                {
                    foreach (string file in input.GetConsumingEnumerable())
                    {
                        List<string> list = new List<string>(MaxBlockSize);
                        using (StreamReader sr = new StreamReader(file))
                        {
                            int countLines = 0;
                            while (!sr.EndOfStream)
                            {
                                list.Add( sr.ReadLine() );
                                countLines++;
                                if (countLines > MaxBlockSize)
                                {
                                    output.Add(list.ToArray());
                                    countLines = 0;
                                    list = new List<string>(MaxBlockSize);
                                }
                            }
                            if (list.Count > 0)
                            {
                                output.Add(list.ToArray());
                            }
                        }
                    }
                }
                finally
                {
                    output.CompleteAdding();
                }
            }
            /// <summary>
            /// Takes string[] blocks from the second pipeline, for each line, splits them by tabs, and parses
            /// the data, storing each line as an object array into the third pipline.
            /// </summary>
            private static void ParseStringBlocks( BlockingCollection<string[]> input, BlockingCollection< Object[][] > output)
            {
                try
                {
                    List<Object[]> result = new List<object[]>(MaxBlockSize);
                    foreach (string[] block in input.GetConsumingEnumerable())
                    {
                        foreach (string line in block)
                        {
                            string[] splitLine = line.Split('\t'); //split line on tab
                            string cityName = splitLine[0];
                            int cityPop = Int32.Parse( splitLine[1] );
                            int cityElevation = Int32.Parse(splitLine[2]);
                            //...
                            result.Add(new Object[] { cityName, cityPop, cityElevation });
                        }
                        output.Add( result.ToArray() );
                    }
                }
                finally
                {
                    output.CompleteAdding();
                }
            }
            /// <summary>
            /// Takes the data blocks from the third pipeline, and uploads each row to SQL Database
            /// </summary>
            private static void UploadBlocks(BlockingCollection<Object[][]> input)
            {
                /*
                 * At this point 'block' is an array of object arrays.
                 * 
                 * The block contains MaxBlockSize number of cities.
                 * 
                 * There is one object array for each city.
                 * 
                 * The object array for the city is in the pre-defined order from pipeline stage2
                 * 
                 * You could do a couple of things at this point:
                 * 
                 * 1. declare and initialize a DataTable with the correct column types
                 *    then, do the  dataTable.Rows.Add( rowValues )
                 *    then, use a Bulk Copy Operation to upload the dataTable to SQL
                 *    http://msdn.microsoft.com/en-us/library/7ek5da1a
                 * 
                 * 2. Manually perform the sql commands/transactions similar to what 
                 *    Kevin recommends in this suggestion:
                 *    http://stackoverflow.com/questions/1024123/sql-insert-one-row-or-multiple-rows-data/1024195#1024195
                 * 
                 * I've demonstrated the first approach with this code.
                 * 
                 * */
                DataTable dataTable = new DataTable();
                //set up columns of dataTable here.
                foreach (Object[][] block in input.GetConsumingEnumerable())
                {
                    foreach (Object[] rowValues in block)
                    {
                        dataTable.Rows.Add(rowValues);
                    }
                    //do bulkCopy to upload table containing MaxBlockSize number of cities right here.
                    dataTable.Rows.Clear(); //Remove the rows when you are done uploading, but not the dataTable.
                }
            }
        }
    }
