    public partial class Form2 : Form
    {
        private static readonly Form2 _formInstance = new Form2();
        private Form2()
        {
            InitializeComponent();
        }
        private void LoadMeaning(string word)
        {
            //The logic to fetch and show the meaning
            .......
            SqlCeConnection con = new SqlCeConnection(@"Data Source=ghjghj.sdf");
            .......
            cmnd.CommandText = "SELECT bangla FROM dic WHERE (english=@w)";
            ... SqlCeDataReader rd = cmnd.ExecuteReader();
            if (rd.Read())
            {   meaning = rd[0].ToString();   }
               else
                   meaning = "No meaning found in your dictionary";
            label6.Text = meaning.ToString();
            label5.Text = word;
            ............
        }
        //Override method to prevent disposing the form when closing.
        protected override void OnClosing(CancelEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }
        public static void show_meaning(string word)
        {
            _formInstance.LoadMeaning(word);
            _formInstance.Show();
        }
    }
