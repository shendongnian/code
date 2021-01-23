           //add filename to the constructor
           public Form1(string filename)
            {
                InitializeComponent();
                List<float> inputList = new List<float>();
                //use the filename from the constructor to open the StreamReader
                TextReader tr = new StreamReader(filename);
                //set your FileName filename passed in
                FileName = filename;
                String input = Convert.ToString(tr.ReadToEnd());
                items = input.Split(',');
                
            }
