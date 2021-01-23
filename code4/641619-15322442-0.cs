    public static bool ExtractToFolder(ExtractionPackage extractionPackage, string extractionPath)
        {
            var fullExtractionPath = Path.Combine(extractionPath, extractionPackage.FolderName);
            try
            {
                using (var reader = RarReader.Open(GetStreams(extractionPackage)))//extractionPackage.ExtractionFiles.Select(p => File.OpenRead(p.FullPath)), Options.None))
                {
                    while (reader.MoveToNextEntry())
                    {
                        reader.WriteEntryToDirectory(fullExtractionPath, ExtractOptions.ExtractFullPath | ExtractOptions.Overwrite);
                    }
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        private static IEnumerable<Stream> GetStreams(ExtractionPackage package)
        {
            foreach (var item in package.ExtractionFiles)
            {
                using (Stream input = File.OpenRead(item.FullPath))
                {
                    yield return input;
                }
            }
        }
