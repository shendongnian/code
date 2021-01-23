            string[] lines = File.ReadAllLines("filename.txt");
            int count = 0;
            int line = 0;
            for (; line < lines.Length; line++)
            {
                count += lines[line].Length;
                if (count >= 1500)
                {
                    // previous line is < 1500
                    Console.WriteLine("Character count < 1500 on line {0}", line - 1);
                    Console.WriteLine("Line {0}: {1}", line - 1, lines[line - 1]);
                    break;
                }
            }
