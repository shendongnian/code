            foreach (string line in lines)
            {
                var words = line.Split( new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                foreach(string w in words)
                    Console.Write("{0,6}", w);
                // filling out
                for (int i = words.Length; i < 8; i++)
                    Console.Write("{0,6}", "0.");
                Console.WriteLine();
            }
