    public static class MacroEventExtensions
    {
        public static void WriteToFile(this List<MacroEvent> events, string path)
        {
            StringBuilder fileContents = new StringBuilder();
            foreach (var e in events)
            {
                fileContents.AppendLine("{0}::{1}",
                    [some event id from the object],
                    [some event message from the object]);
            }
    
            File.WriteAllText(path, fileContents.ToString());
        }
    }
