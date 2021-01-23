            if(File.Exists(args[0]))
            {
                string[] lines = File.ReadAllLines(args[0]);
                foreach(string line in lines)
                {
                     ... process the current line
                }
            }
