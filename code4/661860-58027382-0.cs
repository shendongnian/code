    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using System.Data.SqlClient;
    
    namespace Employees_Details_Management_System
    {
        public partial class ShowEmpDtlsFrm : Form
        {
    
            SqlConnection con = new SqlConnection(@"Data Source = (local); Initial Catalog = sp_emp; Integrated Security = True");
    
            public SqlCommand cmd { get; private set; }
    
            // private SqlCommand cmd;
    
            public ShowEmpDtlsFrm()
            {
                InitializeComponent();
            }
    
            private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
            {
    
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                ShwEmpDtlsLbl.Text = "Employee Database Management";
                comboBox1.Text = "Click";
            }
    
            private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
            {
    
            }
            public void DataGridChk()//Check if DataGrid is empty or not
            {
               if (dataGridView1.RowCount == 1)
                {
                    dataGridView1.Visible = false;
                    MessageBox.Show("The Given " + comboBox1.Text+ " is Invalid  \nEnter Valid " + comboBox1.Text);
                }
            }
    
            public void DbDataFetch(String Qry)//For Fetching data from database
            {
                SqlCommand cmd = new SqlCommand(Qry, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, "emp");
                dataGridView1.DataSource = ds.Tables["emp"].DefaultView;
                DataGridChk();
            }
    
            public void SrchBtn_Click(object sender, EventArgs e)
            {
                try
                {
                    if (comboBox1.Text == "Employee ID" || comboBox1.Text == "Department ID" || comboBox1.Text == "Manager ID")
                    {
                        if (textBox1.Text != "")
                        {
                            con.Open();
                            dataGridView1.Visible = true;
                            if (comboBox1.Text == "Employee ID")
                            {
                                string Qry = "select * from emp where emp_id='" + textBox1.Text + "' ";
                                DbDataFetch(Qry);
                            }
                            else if (comboBox1.Text == "Department ID")
                            {
                                string Qry = "select * from emp where  dep_id='" + textBox1.Text + "'  ";
                                DbDataFetch(Qry);
                            }
                            else if (comboBox1.Text == "Manager ID")
                            {
                                string Qry = "select * from emp where manager_id='" + textBox1.Text + "' ";
                                DbDataFetch(Qry);
                            }
                            con.Close();
                        }
                        else
                        {
                            MessageBox.Show("Please Enter the ID...");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Choose Valid Option...");
                    }
                }
                catch (System.Data.SqlClient.SqlException sqlException)
                {
                    System.Windows.Forms.MessageBox.Show(sqlException.Message);
                    con.Close();
                }
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                EmpDtlsFrm edf = new EmpDtlsFrm();
                edf.Show();
                this.Hide();
            }
        }
    }
