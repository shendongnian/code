        private static void PerformFileTrim(string filename)
        {
            var fileSize = (new System.IO.FileInfo(filename)).Length;
            if (fileSize > 5000000)
            {
                var text = File.ReadAllText(filename);
                var amountToCull = (int)(text.Length * 0.33);
                amountToCull = text.IndexOf('\n', amountToCull);
                var trimmedText = text.Substring(amountToCull + 1);
                File.WriteAllText(filename, trimmedText);
            }
        }
