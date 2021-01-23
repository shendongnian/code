     class Program
        {
           public static long PackageSize = 1024 * 1024 * 100;
            static void Main(string[] args)
            {
                Console.WriteLine("Enter Directory Full Name for Compression : ");
                var dir = Console.ReadLine();
                Console.WriteLine("Zip File saved Location Directory Name : ");
                var savedir = Console.ReadLine();
                Compress(dir,savedir);
                Console.ReadLine();
            }
    
            public static void Compress(string Directory,string SaveDirectory)
            {
                DirectoryInfo di = new DirectoryInfo(Directory);
                long len = 0L;
    
                // Compress the directory's files.
                // Create the compressed file.
    
                var zipFile = Path.Combine(SaveDirectory, DateTime.Now.Ticks + ".zip");
                ZipFile zip = new ZipFile(zipFile);
    
                zip.UseZip64WhenSaving = Zip64Option.Always;
                zip.CompressionLevel = Ionic.Zlib.CompressionLevel.Default;         
    
                foreach (FileInfo fi in di.GetFiles("*.*", SearchOption.AllDirectories))
                {
    
                    // Get the stream of the source file.
                    using (FileStream inFile = fi.OpenRead())
                    {
                        // Prevent compressing hidden.
                        if ((File.GetAttributes(fi.FullName) & FileAttributes.Hidden)
                            != FileAttributes.Hidden)
                        {
    
                            var outFile = new MemoryStream();
                            DeflateStream Compress =
           new DeflateStream(outFile, CompressionMode.Compress, CompressionLevel.Default, true);
                            // Copy the source file into 
                            // the compression stream.
                            inFile.CopyTo(Compress);
                            len += outFile.Length;
    
                            outFile.Seek(0, SeekOrigin.Begin);
                            zip.AddEntry(fi.FullName, outFile);
                            if (len > PackageSize)
                            {
                                zip.RemoveEntry(fi.FullName);
                                zip.Save();
                                outFile.Flush();
                                len = 0;                           
                                zip = new ZipFile(Path.Combine(SaveDirectory, DateTime.Now.Ticks + ".zip"));
                            }
    
                            Console.WriteLine("Compressed {0} from {1} to {2} bytes.",
                           fi.Name, fi.Length.ToString(), outFile.Length.ToString());
                        }
    
                    }
    
                }
            }
        }
