    class Program
    {
        static void Main(string[] args)
        {
            List<TV> myList = new List<TV>();
            myList.Add(new TV { GroupId = "1", Title = "Title 1", Genre = "Genre A" });
            myList.Add(new TV { GroupId = "1", Title = "Title 2", Genre = "Genre A" });
            myList.Add(new TV { GroupId = "1", Title = "Title 3", Genre = "Genre A" });
            myList.Add(new TV { GroupId = "3", Title = "Title 4", Genre = "Genre 18" });
            myList.Add(new TV { GroupId = "A", Title = "Title 5", Genre = "Genre 18" });
            myList.Add(new TV { GroupId = "A", Title = "Title 6", Genre = "Genre A" });
            myList.Add(new TV { GroupId = "B", Title = "Title 7", Genre = "Genre A" });
            myList.Add(new TV { GroupId = "C", Title = "Title 8", Genre = "Genre A" });
            myList.Add(new TV { GroupId = "D", Title = "Title 9", Genre = "Genre 18" });
            myList.Add(new TV { GroupId = "D", Title = "Title 10", Genre = "Genre A" });
            myList.Add(new TV { GroupId = "D", Title = "Title 11", Genre = "Genre A" });
            myList.Add(new TV { GroupId = "E", Title = "Title 12", Genre = "Genre A" });
            string key = "[0-9] [ABC] [DEF] [GHI] [JKL] [MNO] [PQR] [STU] [VWXYZ]";
            string[] keyes = key.Split(' ');
            Dictionary<string, IEnumerable<TV>> groups = new Dictionary<string, IEnumerable<TV>>();
            
            foreach (var pattern in keyes)
            {
                Regex reg = new Regex(pattern, RegexOptions.IgnoreCase);
                groups.Add(pattern, myList.Where(x => reg.IsMatch(x.GroupId)));
            }
            StringBuilder sb = new StringBuilder();
            foreach (var group in groups.Where(x => x.Value.Any()))
            {
                sb.AppendFormat(CultureInfo.CurrentUICulture, "<div id=\"group-{0}\">\n<div>", group.Key.Split(new char[] { '[', ']'})[1]);
                foreach (var tv in group.Value)
                {
                    sb.AppendFormat(CultureInfo.CurrentUICulture, "\n{0}", tv.ToString());
                }
                sb.AppendFormat("\n</div>\n</div>");
            }
            Console.Write(sb.ToString());
            Console.ReadKey();
        }
    }
    internal class TV
    {
        public string GroupId { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public override string ToString()
        {
            return string.Format(CultureInfo.CurrentUICulture, "{0}, {1}, {2}", this.GroupId, this.Title, this.Genre);
        }
    }
