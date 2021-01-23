            string test = "\"abc def ghi\" \"%1\" \"%2\"";
            var splits = test.Split(new string[]{"\" \"","\""},StringSplitOptions.RemoveEmptyEntries);
            foreach (var split in splits)
            {
                Console.WriteLine(split);
            }
