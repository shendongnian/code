    namespace _16953330
    {
        class Program
        {
            static void Main(string[] args)
            {
                byte[] input = Encoding.ASCII.GetBytes(
    @"I have saved data using BinaryWritter in a file. I have saved data using BinaryWritter in a file. I have saved data using BinaryWritter in a file. I have saved data using BinaryWritter in a file. I have saved data using BinaryWritter in a file. I have saved data using BinaryWritter in a file. I have saved data using BinaryWritter in a file. I have saved data using BinaryWritter in a file. I have saved data using BinaryWritter in a file. I have saved data using BinaryWritter in a file. I have saved data using BinaryWritter in a file. I have saved data using BinaryWritter in a file. I have saved data using BinaryWritter in a file. I have saved data using BinaryWritter in a file. I have saved data using BinaryBREAKWritter in a file. I have saved data using BinaryWritter in a file. I have saved data using BinaryWritter in a file. I have saved data using BinaryWritter in a file. "); //just for sampling purposes, considering that what you write is NON-human-readable
                using (var stream = new FileStream("somefile.exe", FileMode.OpenOrCreate))
                {
                    using (var writer = new BinaryWriter(stream))
                    {
                        writer.Write(input);
                    }
                }
    
                byte[] firstPart = null;
                byte[] secondPart = null;
    
                StringBuilder sb = new StringBuilder();
    
                string breaker = "BREAK";
                List<byte> byteList = new List<byte>();
    
                using (var stream = new FileStream("somefile.exe", FileMode.OpenOrCreate))
                {
                    using (var reader = new BinaryReader(stream))
                    {
                        while (reader.BaseStream.Position != reader.BaseStream.Length)
                        {
                            byte currentByte;
                            currentByte = reader.ReadByte();
                            if (currentByte == 'B')
                            {
                                byteList.Add(currentByte);
                                for (int i = 1; i < breaker.Length; i++)
                                {
                                    currentByte = reader.ReadByte();
                                    byteList.Add(currentByte);
                                    //if the succeeding characters match the characters after B in BREAK
                                    if ((char)currentByte == breaker[i] && i > 1)
                                    {
                                        byteList.RemoveAt(byteList.Count - 1);
                                        if (i == breaker.Length - 1)
                                        {
                                            //if the for loop reaches its end and matches all characters in BREAK
                                            //remove B (which was added above) and K (added last)
                                            byteList.RemoveAt(byteList.Count - 1);
                                            byteList.RemoveAt(byteList.Count - 1);
                                            firstPart = byteList.ToArray();
                                            byteList.Clear();
                                        }
                                    }
                                }
                            }
                            else
                            {
                                byteList.Add(currentByte);
                            }
                        }
                        secondPart = byteList.ToArray();
                    }
                }
    
                Console.WriteLine(firstPart);
                Console.WriteLine(Environment.NewLine);
                Console.WriteLine(secondPart);
            }
        }
    }
