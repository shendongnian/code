    namespace _16953330
    {
        class Program
        {
            static void Main(string[] args)
            {
                string input =
    @"The quick brown fox jumps over the lazy dog.
    The quick brown fox jumps over the lazy dog.
    The quick brown fox jumps over the lazy dog.
    The quick brown fox jumps over the lazy dog.
    The quick brown fox jumps over the lazy dog.
    The quick brown fox jumps over the lazy dog.
    fox jumps over the lazy dfox jumps over the lazy dBREAK fox jumps over the lazy dfox jumps over the lazy d
    The quick brown fox jumps over the lazy dog.
    The quick brown fox jumps over the lazy dog.
    The quick brown fox jumps over the lazy dog.
    The quick brown fox jumps over the lazy dog.
    The quick brown fox jumps over the lazy dog.
    The quick brown fox jumps over the lazy dog.";
                using (var stream = new FileStream("file.txt", FileMode.OpenOrCreate))
                {
                    using (var writer = new BinaryWriter(stream)) //why use a BinaryWriter if you're gonna write in a human-readable format?
                    {
                        writer.Write(input);
                    }
                }
    
                string firstPart = string.Empty;
                string secondPart = string.Empty;
    
                StringBuilder sb = new StringBuilder();
    
                using (var stream = new FileStream("file.txt", FileMode.OpenOrCreate))
                {
                    using (var reader = new StreamReader(stream))
                    {
                        string line;
                        while (!string.IsNullOrEmpty(line = reader.ReadLine()))
                        {
                            int indexOfBreak = line.IndexOf("BREAK");
                            if (indexOfBreak == -1)
                            {
                                sb.Append(line);
                            }
                            else
                            {
                                string untilBeforeBREAK = line.Substring(0, indexOfBreak);
                                sb.Append(untilBeforeBREAK);
                                //remove the first 2 characters in the file as the BinaryWriter 
                                //writes the length of the bytes should a BinaryReader expect
                                //(if ever you want to use a binary reader which I don't understand
                                //because you are reading a HUMAN READABLE file)
                                firstPart = sb.Remove(0,2).ToString(); 
    
                                sb.Clear();
    
                                string breakUpToTheEnd = string.Empty;
                                sb.Append(line.Substring(indexOfBreak));
                                sb.Append(reader.ReadToEnd());
                                secondPart = sb.ToString();
                            }
                        }
                    }
                }
    
                Console.WriteLine(firstPart);
                Console.WriteLine(Environment.NewLine);
                Console.WriteLine(secondPart);
    
            }
        }
    }
