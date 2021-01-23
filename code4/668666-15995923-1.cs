    {
        string fileName = @"d:\temp\blacklist.txt";
        char seperator = ';';
        public Form1()
        {
            InitializeComponent();
            string[] users = { "Dave", "John", "Shawn" };
            //Save(users);
            users = Load();
        }
        public string[] Load()
        {
            string line;
            using (StreamReader sr = new StreamReader(this.fileName))
            {
                line = sr.ReadToEnd();
            }
            return line.Split(seperator);
        }
        public void Save(string[] users)
        {
            using (StreamWriter sw = new StreamWriter(this.fileName))
            {
                string line = string.Empty;
                foreach (string user in users)
                {
                    line += string.Format("{0}{1}", user, seperator);
                }
                sw.WriteLine(line);
                sw.Flush();
            }
        }
    }
