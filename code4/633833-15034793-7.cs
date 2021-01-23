    namespace WindowsFormsApplication9
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
            DataGridViewTextBoxColumn tb = new DataGridViewTextBoxColumn();
            DataGridViewCheckBoxColumn cb = new DataGridViewCheckBoxColumn();
            private void Form1_Load(object sender, EventArgs e)
            {
                FormatGrid(dataGridView1);
                LoadDg();
            }
            private void FormatGrid(DataGridView dg)
            {
                dg.Columns.Add(tb);
                dg.Columns[0].HeaderText = "EName";
                dg.Columns[0].Width = 199;
    
                dg.Columns.Add(cb);
                dg.Columns[1].HeaderText = "Attended";
                dg.Columns[1].Width = 69;            
            }
            private void LoadDg()
            {
                SqlConnection cn = new SqlConnection("data source=localhost;initial catalog=acc;uid=sa;pwd=emotions");                
                SqlDataAdapter da = new SqlDataAdapter("select Employees.EName, EmpAttendedTheMeeting.EName from Employees left join EmpAttendedTheMeeting on Employees.EName = EmpAttendedTheMeeting.EName", cn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {                
                    
                    dataGridView1.Rows.Add(dr[0], dr[1].ToString() == string.Empty ? false : true);
                }
            }   
            
        }
    }
