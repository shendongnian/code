    public class MyCustomComparer : IComparer<FileInfo>
    {
        public int Compare(FileInfo x, FileInfo y)
        {
            string[] parts1 = x.Name.Split('-');
            string[] parts2 = y.Name.Split('-');
            int toPad1 = 10 - parts1[0].Length;
            int toPad2 = 10 - parts2[0].Length;
            parts1[0] = parts1[0].Insert(0, new String('0', toPad1));
            parts2[0] = parts2[0].Insert(0, new String('0', toPad2));
            string toCompare1 = string.Join("", parts1);
            string toCompare2 = string.Join("", parts2);
            return toCompare1.CompareTo(toCompare2);
        }
    }
