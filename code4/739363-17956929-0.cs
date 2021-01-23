        static void ReadFile(string path)
        {
            var lines = System.IO.File.ReadAllLines(path).ToList();
            var infos = new List<TextFileInfo>();
            var info = new TextFileInfo();
            var currentLine = 0;
            while (lines.Count > 0)
            {
                TryReadLine(lines[0], info);
                if (currentLine++ >= 3)
                {
                    currentLine = 0;
                    infos.Add(info);
                    info = new TextFileInfo();
                }
                lines.RemoveAt(0);
            }
            //Do something with infos
            // return infos;
       }
        public static void TryReadLine(string line, TextFileInfo info)
        {
            if (line.StartsWith(DateTag))
            {
                var value = line.Replace(DateTag, string.Empty).Trim();
                info.Date = DateTime.Parse(value);
                return;
            }
            if (line.StartsWith(SourcePathTag))
            {
                var value = line.Replace(SourcePathTag, string.Empty).Trim();
                info.SourcePath = value;
                return;
            }
            if (line.StartsWith(DestinationPathTag))
            {
                var value = line.Replace(SourcePathTag, string.Empty).Trim();
                info.DestinationPath = value;
                return;
            }
            if (line.StartsWith(LastFolderUpdatedTag))
            {
                var value = line.Replace(SourcePathTag, string.Empty).Trim();
                info.LastFolderUpdated = value;
                return;
            }
            throw new Exception("Invalid line encountered");
        }
        public class TextFileInfo
        {
            public DateTime Date { get; set; }
            public string SourcePath { get; set; }
            public string DestinationPath { get; set; }
            public string LastFolderUpdated { get; set; }
        }
