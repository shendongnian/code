            var stringBuilder = new StringBuilder();
            using (TextWriter writer = new StringWriter(stringBuilder))
            {
                writer.Write("A");
                writer.WriteLine();
                writer.Write("B");
            }
            string fullString = stringBuilder.ToString();
            string[] newline = new string[] { Environment.NewLine };
            string[] arrayOfString = fullString.Split(newline, StringSplitOptions.RemoveEmptyEntries);
            // Returns false but should return true
            Console.WriteLine(arrayOfString.Length == 2);
