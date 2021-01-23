    public partial class Form1 : Form
    {
                SqlConnection con = null; 
                SqlDataAdapter da = null; 
                DataSet dsl =  null;     
            
            
                public Form1()
                {
                    InitializeComponent();
                    con = new SqlConnection(@"Data Source=TALY-PC;Initial Catalog=Katalogi;Integrated Security=True;Pooling=False");
                     da = new SqlDataAdapter("SELECT * FROM tblArtikujt", con);
                    dsl = new DataSet();    
                }
    }
