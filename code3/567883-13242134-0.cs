    namespace mysql_windows_console
    {
    public partial class Form1 : Form
    {
        MySqlConnection konekcija;
        string baza = "server=localhost;database=test;user=root;password=;"; //so you can access it again if you need it b any chance
        public Form1()
        {
            InitializeComponent();
            konekcija = new MySqlConnection(baza);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            konekcija.Open();
            string sql = "SELECT IME,PREZIME FROM tabela";
            MySqlDataAdapter adapter = new MySqlDataAdapter(sql,konekcija);
            DataTable tab = new DataTable();
            adapter.Fill(tab);
            dataGridView1.DataSource = tab;
            konekcija.Close();
        }
    }
}
