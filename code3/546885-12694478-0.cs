       string URL = null;
    
       public static void Main(string[] args)
            {
                Console.WriteLine(args[0]);
                URL = args[0];
            }
    
    private void Form1_Load(object sender, EventArgs e)
        {
            panel3.BackColor = Doga_Rhodonit.Properties.Settings.Default.themebg;
    
            ((WebKitBrowser)tabControl1.SelectedTab.Controls[0]).Navigate(URL);
