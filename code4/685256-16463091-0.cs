    public partial class FormShowMeaning : Form
    {
        private static readonly FormShowMeaning _formInstance = new FormShowMeaning();
        private FormShowMeaning()
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
        public static void ShowMeaning(string word)
        {
            _formInstance.LoadMeaning(word);
            _formInstance.Show();
        }
    }
