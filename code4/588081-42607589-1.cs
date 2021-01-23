    static SqlConnection con = new SqlConnection(@"Data Source=TALY-PC;Initial Catalog=Katalogi;Integrated Security=True;Pooling=False");
    SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM tblArtikujt", con);
    DataSet dsl = new DataSet();
    public Form1()
    {
        InitializeComponent();
    }
