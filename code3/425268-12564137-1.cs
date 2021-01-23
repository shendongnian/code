        public static void DictToCsv(Dictionary<string, string> dict, string filePath)
        {
            try
            {
                var csvLines = String.Join(Environment.NewLine,
                       dict.Select(d => d.Key + "," + d.Value));
                Directory.CreateDirectory(Path.GetDirectoryName(filePath))
                File.WriteAllText(filePath, csvLines);
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());
            }
        }
