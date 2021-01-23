            string[] lines = System.IO.File.ReadAllLines("Sample.txt");
            for (int i = 0; i < lines.Length; i++)
            {
                if(lines[i].Contains("hi"))
                {
                    MessageBox.Show("Found");
                    lines[i] = lines[i].Replace("hi", "BYE");
                    break;
                }
            }
            System.IO.File.WriteAllLines("Sample.txt", lines);
