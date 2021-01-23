    using System;
    using System.Collections;
    using System.IO;
    using Ionic.Zip;
    using Ionic.Zlib;
    
    namespace ZipFileSize1
    {
        /// <summary>
        /// This source code is generate the specified size Packages from the directory.
        /// </summary>
        class Program
        {
            /// <summary>
            /// The size of Package(100MB).
            /// </summary>
            public static long m_packageSize = 1024 * 1024 * 100;
    
            /// <summary>
            ///  Main method of program class.
            /// </summary>
            /// <param name="args">Command line argument</param>
            static void Main(string[] args)
            {
                Console.WriteLine("Enter Directory Full Name for Compression : ");
                var dir = Console.ReadLine();
                Console.WriteLine("Zip File saved Location Directory Name : ");
                var savedir = Console.ReadLine();
    
                //generate the random zip files.
    
                var zipFile = Path.Combine(savedir, DateTime.Now.Ticks + ".zip");
                ZipFiles(dir, savedir);
    
                Console.ReadLine();
            }
    
            /// <summary>
            /// This method generate the package as per the <c>PackageSize</c> declare.
            /// Currently <c>PackageSize</c> is 100MB.
            /// </summary>
            /// <param name="inputFolderPath">Input folder Path.</param>
            /// <param name="outputFolderandFile">Output folder Path.</param>
            public static void ZipFiles(string inputFolderPath, string outputFolderandFile)
            {
                ArrayList ar = GenerateFileList(inputFolderPath); // generate file list
                int trimLength = (Directory.GetParent(inputFolderPath)).ToString().Length;
                // find number of chars to remove 	// from original file path
                trimLength += 1; //remove '\'
                
                // Output file stream of package.
                FileStream ostream;
                byte[] obuffer;
    
                // Output Zip file name.
                string outPath = Path.Combine(outputFolderandFile, DateTime.Now.Ticks + ".zip");
    
                ZipOutputStream oZipStream = new ZipOutputStream(File.Create(outPath), true); // create zip stream
    
                // Compression level of zip file.
                oZipStream.CompressionLevel = CompressionLevel.Default;
    
                // Initialize the zip entry object.
                ZipEntry oZipEntry = new ZipEntry();
    
                // numbers of files in file list.
                var counter = ar.Count;
                try
                {
                    using (ZipFile zip = new ZipFile())
                    {
                        Array.Sort(ar.ToArray());  // Sort the file list array.
                        foreach (string Fil in ar.ToArray()) // for each file, generate a zip entry
                        {
                            if (!Fil.EndsWith(@"/")) // if a file ends with '/' its a directory
                            {
    
                                if (!zip.ContainsEntry(Path.GetFullPath(Fil.ToString())))
                                {
                                    oZipEntry = zip.AddEntry(Path.GetFullPath(Fil.ToString()), Fil.Remove(0, trimLength));
                                    counter--;
                                    try
                                    {
                                        if (counter > 0)
                                        {
                                            if (oZipStream.Position < m_packageSize)
                                            {
                                                oZipStream.PutNextEntry(oZipEntry.FileName);
                                                ostream = File.OpenRead(Fil);
                                                obuffer = new byte[ostream.Length];
                                                ostream.Read(obuffer, 0, obuffer.Length);
                                                oZipStream.Write(obuffer, 0, obuffer.Length);
                                            }
    
                                            if (oZipStream.Position > m_packageSize)
                                            {
                                                zip.RemoveEntry(oZipEntry);
                                                oZipStream.Flush();
                                                oZipStream.Close(); // close the zip stream.
                                                outPath = Path.Combine(outputFolderandFile, DateTime.Now.Ticks + ".zip"); // create new output zip file when package size.
                                                oZipStream = new ZipOutputStream(File.Create(outPath), true); // create zip stream                                                
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("No more file existed in directory");
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine(ex.Message);
                                        zip.RemoveEntry(oZipEntry.FileName);
                                    }
    
                                }
                                else
                                {
                                    Console.WriteLine("File Existed {0} in Zip {1}", Path.GetFullPath(Fil.ToString()), outPath);
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                   
                }
                finally
                {
                    oZipStream.Flush();
                    oZipStream.Close();// close stream
                    Console.WriteLine("Remain Files{0}", counter);
                }
            }
    
            /// <summary>
            /// This method return the list of files from the directory
            /// Also read the child directory also, but not add the 0 length file.
            /// </summary>
            /// <param name="Dir">Name of directory.</param>
            /// <returns>return the list of all files including into subdirectory files </returns>
            private static ArrayList GenerateFileList(string Dir)
            {
                ArrayList fils = new ArrayList();
    
                foreach (string file in Directory.GetFiles(Dir, "*.*", SearchOption.AllDirectories)) // add each file in directory
                {
                    if (File.ReadAllBytes(file).Length > 0)
                        fils.Add(file);
                }
    
                return fils; // return file list
            }      
        }
    }
