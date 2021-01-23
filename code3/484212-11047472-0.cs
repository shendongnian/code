    using System.Data;
    using System.Data.SqlClient;
    using System.Windows.Forms;
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                FillData();
            }
            void FillData()
            {
                var connString = ConfigurationManager
                    .ConnectionStrings[name].ConnectionString;
                    
                using (SqlConnection c = new SqlConnection(connString))
                {
                    c.Open();
                
                    // use a SqlAdapter to execute the query
                    using (SqlDataAdapter a = new SqlDataAdapter("SELECT * FROM EmployeeIDs", c))
                    {            
                        // fill a data table
                        var t = new DataTable();
                        a.Fill(t);
                        // Bind the table to the list box
                        listBox1.DisplayMember = "NameOfColumnToBeDisplayed";
                        listBox1.ValueMember = "NameOfColumnToUseValueFrom";
                        listBox1.DataSource = t;
                    }
                }
            }
        }        
    }
