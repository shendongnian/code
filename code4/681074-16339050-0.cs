    private  void SHA256Directory(string directory)
        {
            SHA256 DirectorySHA256 = SHA256Managed.Create();
            byte[] hashValue;
            DirectoryInfo dir = new DirectoryInfo(directory);
            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo fInfo in files)
            {
                try
                {
                    FileStream fStream = fInfo.Open(FileMode.Open);
                    fStream.Position = 0;
                    hashValue = DirectorySHA256.ComputeHash(fStream);
                    Console.WriteLine(fInfo.Name);
                    Miscellaneous.ByteArrayToHex(hashValue);
                    Miscellaneous.ByteArrayToBase64(hashValue);
                    Console.WriteLine();
                    fStream.Close();
                }
                catch (DirectoryNotFoundException)
                {
                    Console.WriteLine("Error: The directory specified could not be found.");
                }
                catch (UnauthorizedAccessException)
                {
                    Console.WriteLine("Error: A file in the directory could not be accessed.in {0}", fInfo.Name);
                }
                catch (ArgumentNullException)
                {
                    Console.WriteLine("Error: The argument cannot be null or empty.");
                }
                catch (IOException)
                {
                    Console.WriteLine("Error:IOExcepiton occured");
                }
            }
            return;
        }
