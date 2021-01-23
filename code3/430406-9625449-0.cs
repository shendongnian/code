            var list = new List<string[]>();
            using (StreamReader reader = new StreamReader("Test.txt"))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    list.Add(line.Split(' '));
                }
            }
            string firstWord = list[0][0]; //12345 
            string secondWord = list[0][1]; //Test
