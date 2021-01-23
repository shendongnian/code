    public class CustomFileInfo :IComparable<CustomFileInfo>
    {
        public string Name { get; set; }
        public string MoreName { get; set; }
        public DateTime FileDate { get; set; }
        public int Number { get; set; }
        public DateTime FileTime { get; set; }
        public CustomFileInfo(string fileNameString)
        {
            string[] fileNameStringSplited = fileNameString.Split('_');
            this.Name = fileNameStringSplited[0];
            this.MoreName = fileNameStringSplited[1];
            this.FileDate = DateTime.ParseExact(fileNameStringSplited[2], "ddMMyyyy", null);
            this.Number = int.Parse(fileNameStringSplited[3]);
            this.FileTime = DateTime.ParseExact(fileNameStringSplited[4], "HHmmss", null);
        }
        public int CompareTo(CustomFileInfo other)
        {
            // add more comparison criteria here
            if (this.FileDate == other.FileDate) 
                return 0;
            if (this.FileDate > other.FileDate)
                return 1;
            return -1;
        }
    }
