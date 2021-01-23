    public Form1()
        {
            InitializeComponent();
            const string mail = "First";
            const string mail1 = "Second";
            const string mail2 = "Third";
            const string mail3 = "";
            const string mail4 = "Fifth";
            var mails = new string[] { mail, mail1, mail2, mail3, mail4 };
            ChangeCellEmail(2, mails);
        }
        public void ChangeCellEmail(int col, string[] emails)
        {
            var sep = ";";
            var text = "";
            var tempVar = ""; //New temp variable (representing your dataGrid.value)
            for (int emailList = 1; emailList < 5; emailList++)
            {
                for (var i = 0; i < emails.Length; i++)
                {
                    if (emails[i].Trim() != "")
                    {
                        text = text + emails[i] + sep;
                        tempVar = text;
                    }
                    else
                    {
                        tempVar = string.Empty;
                    }
                }
            }
        }
