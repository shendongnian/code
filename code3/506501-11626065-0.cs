        namespace Test
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            const string path = @"C:\Kelimeler\Test.txt";
            private void Form1_Load(object sender, EventArgs e)
            {
                SqlConnection conn = new SqlConnection("Server=.;Database=Northwind; UID=sa;PWD=1234");
                SqlCommand cmd = new SqlCommand("Select ShipperID, CompanyName,Phone FROM Shippers", conn);
    
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dtSource = new DataTable();
                da.Fill(dtSource);
    
                dt.DataSource = dtSource;
    
                if (dt != null)
                {
                    if (!File.Exists(path))
                    {
                        File.Create(path);
                    }
    
                    foreach (DataGridViewRow row in dt.Rows)
                    {
                        for (int i = 0; i < dt.ColumnCount; i++)
                        {
                            File.AppendAllText(path, row.Cells[i].Value.ToString());
                            File.AppendAllText(path, ", ");
                        }
                    }
                }
            }
        }
    }
