            foreach (string path in fileEntries)
            {
                ...
                string text = reader.ReadLine();
                // while the text being read in from reader.Readline() is not null
                while (text != null)
                {
                    string[] words = text.Split(',');
                    noise.Add(Convert.ToSingle(words[3]));
                    // write text to a file
                    tw3.WriteLine(text);
                    //foreach (string word in words)
                    //{
                    //    tw.WriteLine(word);
                    //}
                    ...
                    text = reader.ReadLine();
                }
                tw3.Close();
            }
