            using (BinaryReader inFile = new BinaryReader(File.Open(@"C:\file.bin", FileMode.Open),Encoding.ASCII))
            {
                int pos = 0;
                int length = (int)inFile.BaseStream.Length;
                int sizeToRead;
                while (pos < length)
                {
                    Console.WriteLine("get size to read"); // prints this out
                    sizeToRead = inFile.ReadInt32();
                    Console.WriteLine("Size: {0}", sizeToRead); // doesn't print this out, or anything after
                }
                Console.WriteLine("Done"); // end file processing
            }
