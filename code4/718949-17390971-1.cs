        public Form1()
        {
            InitializeComponent();
            List<List<string>> MyList = MakeList(@"C:\InFile.txt");
            MessageBox.Show(MyList[1][1]);
        }
        public List<List<string>> MakeList(string Path)
        {
            List<List<string>> TempList = new List<List<string>>();
            System.IO.StreamReader sr = new System.IO.StreamReader(Path);
            while (!sr.EndOfStream)
            {
                string Temp = sr.ReadLine();
                TempList.Add(Temp.Split().ToList<string>());
            }
            return TempList;
        }
