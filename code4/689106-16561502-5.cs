    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            DatabaseCheckTest();
        }
        private void DatabaseCheckTest()
        {
            DataTable dt = SelectALL("SELECT * FROM QuickMem");
            MessageBox.Show("All done");
        }
        public DataTable SelectALL(string SQL)
        {
            string folderPath = "C:\\Users\\drook\\Documents\\Database1.accdb";    
            string strAccessConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source= " + folderPath;    
            string strAccessSelect = SQL;    
            DataSet myDataSet = new DataSet();
            OleDbConnection myAccessConn = null;    
            myAccessConn = new OleDbConnection(strAccessConn);    
            OleDbCommand myAccessCommand = new OleDbCommand(strAccessSelect, myAccessConn);
            OleDbDataAdapter myDataAdapter = new OleDbDataAdapter(myAccessCommand);
            myAccessConn.Open();    
            myDataAdapter.Fill(myDataSet, "QuickMem");    
            myAccessConn.Close();
            DataTableCollection dta = myDataSet.Tables;
            return dta[0];    
        }
    }
