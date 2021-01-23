    using System;
    using System.Data;
    using System.Windows.Forms;
    using System.Data.SqlClient;
    
    namespace WindowsFormsApplication12
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
            SqlConnection cn = new SqlConnection("data source=localhost;initial catalog=acc;uid=sa;pwd=emotions");
            private void Form1_Load(object sender, EventArgs e)
            {
                SqlDataAdapter da = new SqlDataAdapter("select ClassId, Class from Class order by ClassId", cn);
                DataTable dt = new DataTable();            
                da.Fill(dt);
                comboBox1.DataSource = dt;
                comboBox1.DisplayMember = "Class";
                comboBox1.ValueMember = "ClassId";
            }
            private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
            {
                SqlDataAdapter da = new SqlDataAdapter("select SNAme, FName, SPhoneNo from Students where ClassId =" + comboBox1.SelectedValue, cn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
        }
    }
