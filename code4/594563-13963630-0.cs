    using System;
    using System.IO;
    namespace myFileRead
    {
        class Program
         {
           static void Main(string[] args)
           {
               // Let's create new data file.
               string myFileName = @"C:\Integers.dat";
                //check if already exists
                if (File.Exists(myFileName))
                   {
                    Console.WriteLine(myFileName + " already exists in the selected directory.");
    
                    return;
                }
    
                FileStream fs = new FileStream(myFileName, FileMode.CreateNew);
    
                // Instantialte a Binary writer to write data
    
                BinaryWriter bw = new BinaryWriter(fs);
    
                // write some data with bw
    
                for (int i = 0; i < 100; i++)
    
                {
                        bw.Write((int)i);
                }
    
                bw.Close();
                fs.Close();
    
                // Instantiate a reader to read content from file
                fs = new FileStream(myFileName, FileMode.Open, FileAccess.Read);
    
                BinaryReader br = new BinaryReader(fs);
    
                // Read data from the file
    
                for (int i = 0; i < 100; i++)
                {
                    //read data as Int32 
                    Console.WriteLine(br.ReadInt32());
                }
                //close the file 
                br.Close();
                fs.Close();           
           }
    
        }
    
    }
