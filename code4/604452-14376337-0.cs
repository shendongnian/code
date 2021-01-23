    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.Data.SqlClient;
    
    namespace datagridview
    {
        public partial class Form1 : Form
        {
            SqlConnection con = new SqlConnection();
            SqlDataAdapter da = new SqlDataAdapter();
    
            
    
    
    public Form1()
            {
                InitializeComponent();
            }
    
    
    
    
            private void btnshow_Click(object sender, EventArgs e)
            {
            try
                {
                    con.ConnectionString = "Data Source=CHANDU-PC;Initial Catalog=Class;Integrated Security=true;MultipleActiveResultSets=true;";
                    con.Open();
                    SqlCommand cmd = new SqlCommand("select * from student1", con);
                    da.SelectCommand = cmd;
                    cmd.ExecuteNonQuery();
                    DataSet ds = new DataSet();
                    da.Fill(ds, "student1");
                    dataGridView1.DataSource = ds.Tables[0];
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Exception caught : " + ex.Message.ToString());
                }
                finally
                {
                    con.Close();
                }
            }
    
          
           
     private void Form1_Load(object sender, EventArgs e)
            {
                try
                {
                    con.ConnectionString = "Data Source=CHANDU-PC;Initial Catalog=Class;Integrated Security=true;MultipleActiveResultSets=true;";
                    con.Open();
                    SqlCommand cmd = new SqlCommand("select * from student1", con);
                    da.SelectCommand = cmd;
                    cmd.ExecuteNonQuery();
                    DataSet ds = new DataSet();
                    da.Fill(ds, "student1");
                    dataGridView1.DataSource = ds.Tables[0];
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Exception caught : " + ex.Message.ToString());
                }
                finally
                {
                    con.Close();
                }
            }
    
            string s,s1,s2;
            int x, y;
    
    
    
            private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
            {
            }
    
    
    
            private void dataGridView1_CancelRowEdit(object sender, QuestionEventArgs e)
            {
                x = -1;
                y = -1;
            }
    
    
    
            private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
            {
                x = dataGridView1.CurrentCellAddress.X;
                y = dataGridView1.CurrentCellAddress.Y;
            }
    
    
    
            private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
            {
                try
                {
                    con.ConnectionString = "Data Source=CHANDU-PC;Initial Catalog=Class;Integrated Security=true;MultipleActiveResultSets=true;";
                    con.Open();
                    SqlCommand cmd;
                    int i = -1,j;
                    if (e.ColumnIndex == 0)
                    {
                        j = (int)Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
                        s1 = "";
                        s2 = "";
                        cmd = new SqlCommand("insert into student1 values('" +j+ "','" + s1 + "','" + s2 + "')", con);
                        da.InsertCommand = cmd;
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("id inserted successfully");
                    }
                    else
                    {
                        s = (string)dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                        i = (int)Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
                        if (e.ColumnIndex == 1)
                            cmd = new SqlCommand("update student1 set name='" + s + "' where id='" + i + "'", con);
                        else
                            cmd = new SqlCommand("update student1 set email='" + s + "' where id='" + i + "'", con);
                        da.UpdateCommand = cmd;
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Information updated Successfully");
                    }
                    }
                catch (Exception ex)
                {
                    MessageBox.Show("Exception caught : " + ex.Message.ToString());
                }
                finally
                {
                    con.Close();
                }
            }
    
    
    
            private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
            {
                dataGridView1.Refresh();
            }
    
    
    
            private void dataGridView1_AllowUserToAddRowsChanged(object sender, EventArgs e)
            {
    
            }
    
    
    
            private void dataGridView1_KeyUp(object sender, KeyEventArgs e)
            {
                if (e.KeyCode == Keys.Delete)
                {
                        try
                        {
                            SqlConnection con2 = new SqlConnection();
                            SqlDataAdapter da2 = new SqlDataAdapter();
                            con2.ConnectionString = "Data Source=CHANDU-PC;Initial Catalog=Class;Integrated Security=true;MultipleActiveResultSets=true;";
                            con2.Open();
                            x = (int)Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                            SqlCommand cmd2 = new SqlCommand("delete student1 where id='" + x + "'", con2);
                            da2.DeleteCommand = cmd2;
                            cmd2.ExecuteNonQuery();
                            MessageBox.Show("Information deleted Successfully");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Exception caught : " + ex.Message.ToString());
                        }
                        finally
                        {
                            con.Close();
                        }
                    }
                }
    
    
    
            private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
            {
    
            }
        }
    }
