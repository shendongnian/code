    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication6
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                this.DataGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGrid_CellClick);
            }
            SqlConnection cn = new SqlConnection("data source=localhost;initial catalog=acc;integrated security=true");
            private void Form1_Load(object sender, EventArgs e)
            {
                TBStudentID.Enabled = false;
                GetData();
            }
            private void GetData()
            {
                SqlDataAdapter da = new SqlDataAdapter("select * from StudentInfo", cn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                DataGrid.DataSource = dt;
            }
            private void BtnSave_Click(object sender, EventArgs e)
            {
                SqlCommand cmd = new SqlCommand("insert into StudentInfo(SName, FName, Class) values('" + TBSName.Text + "','" + TBFName.Text + "','" + TBClass.Text + "')", cn);
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                GetData();
            }
            // using this CellClick event you will be able to get the selected row values
            // in Respective TextBoxes by clicking any of the datagridview rows
            private void DataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
            {
                try
                {
                    TBStudentID.Text = DataGrid.Rows[e.RowIndex].Cells[0].Value.ToString();
                    TBSName.Text = DataGrid.Rows[e.RowIndex].Cells[1].Value.ToString();
                    TBFName.Text = DataGrid.Rows[e.RowIndex].Cells[2].Value.ToString();
                    TBClass.Text = DataGrid.Rows[e.RowIndex].Cells[3].Value.ToString();
                }
                catch (Exception)
                {
                }
            }
            private void TextBoxClear()
            {
                TBStudentID.Text = null;
                TBSName.Text = null;
                TBFName.Text = null;
                TBClass.Text = null;
            }
            private void BtnDelete_Click(object sender, EventArgs e)
            {
                SqlCommand cmd = new SqlCommand("delete from StudentInfo where StudentId = '" + TBStudentID.Text + "'", cn);
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                GetData();
                TextBoxClear();
            }
    
            private void BtnUpdate_Click(object sender, EventArgs e)
            {
                SqlCommand cmd = new SqlCommand("update StudentInfo set SName = '" + TBSName.Text + "', FName = '" + TBFName.Text + "', Class = '" + TBClass.Text + "' where StudentId = '" + TBStudentID.Text + "'", cn);
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                GetData();
                TextBoxClear();
            }
        }
    }
