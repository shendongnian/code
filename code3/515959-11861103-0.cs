            public static string ExtractFolderFromPath(string fileName, string pathSeparator, bool includeSeparatorAtEnd)
            {
                int pos = fileName.LastIndexOf(pathSeparator);
                return fileName.Substring(0,(includeSeparatorAtEnd ? pos+1 : pos));
            }
