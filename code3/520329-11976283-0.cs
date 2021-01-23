    public partial class Form1 : Form 
    { 
        OleDbConnection baglanti = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Burak YEŞİLYURT\Desktop\secret.accdb"); 
        OleDbCommand komutcu; 
        OleDbDataAdapter adpt; 
        DataSet ds; 
        public Form1() 
        { 
            InitializeComponent(); 
            baglanti.Open(); 
            OleDbCommand komutcu = new OleDbCommand("SELECT * FROM todo", baglanti); 
            OleDbDataAdapter adpt = new OleDbDataAdapter(komutcu); 
            ds = new DataSet(); 
            adpt.Fill(ds); 
            dataGridView1.DataSource = ds.Tables[0]; 
    
        } 
    
        private void button1_Click(object sender, EventArgs e) 
        { 
            OleDbCommandBuilder komut = new OleDbCommandBuilder(adpt); 
            DataSet yeni = new DataSet(); 
            yeni = ds.GetChanges(DataRowState.Modified); //here i get the error
            adpt.Update(yeni.Tables[0]); 
        } 
    } 
