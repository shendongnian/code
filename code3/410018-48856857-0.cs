    public partial class Form1 : Form
    {
       private SqlCeConnection _conn;
    
       public Form1()
       {
           InitializeComponent();
           _conn = new SqlCeConnection(@"Data Source = |DataDirectory|\Database1.sdf");
           this.dataGridView1.AutoGenerateColumns = true;
       }
    
       private void Form1_Load(object sender, EventArgs e)
       {
           SqlCeCommand sqlcmd = new SqlCeCommand();
           sqlcmd.Connection = _conn;
           sqlcmd.CommandText = "SELECT ID, UserName FROM Table1";
           _conn.Open();
    
           SqlCeResultSet rs = sqlcmd.ExecuteResultSet(ResultSetOptions.Scrollable);
           this.bindingSource1.DataSource = rs;
    //dont close the connection
          // _conn.Close();
    
       }
    
    protected override Close()
    {
    if (_conn != null)
    _conn.close();
    base.Close()
    }
    }
