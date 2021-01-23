            using (var writer = new System.IO.StreamWriter("Output.txt"))
            {
                foreach (var s in result)
                {
                    writer.Write(s);
                }
            }
