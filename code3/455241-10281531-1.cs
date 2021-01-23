    //Define the variable as an attribute of class
    private string[] strRadio;
    public Form1()
    {
            InitializeComponent();
            string strRadio = Utils.ReadFile(strTemp + @"\rstations.txt");
            aRadio = strRadio.Split(new string[] { "#" }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < aRadio.Length; i += 2)
            {
               listBox.Items.Add(aRadio[i]);
            }
        }
        private void listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = listBox.SelectedIndex;
            MessageBox.Show(aRadio[(index+1)]);
        }
    }
