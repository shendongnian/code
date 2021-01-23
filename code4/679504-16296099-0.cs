     public partial class formMain : Form
        {
            private Search _searchbox;
            ...
    private void formMain_Load(object sender, EventArgs e)
    {
        _searchbox = new Search();
        _searchbox.btnSearchClicked += new EventHandler(SearchClicked);
    }
    void SearchClicked(object sender, EventArgs e)
            {
           
         Search content = _searchbox;
    
    MySqlConnection con = new MySqlConnection(serverstring);
    
                try
                {
    
                    string query = "SELECT * FROM tblclassification WHERE INSTR(class_name, @search)";
    
                    MySqlCommand cmd = new MySqlCommand(query, con);
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
    
                   
                    cmd.Parameters.AddWithValue("@search", content.btnsearch.Text);
    
                    DataTable dt = new DataTable();
                    da.Fill(dt);
    
    
                    classification control = new classification();
                    control.dataGridView1.DataSource = dt;
                    control.dataGridView1.DataMember = dt.TableName;
    
                    panelMain.Controls.Clear();
                    panelMain.Controls.Add(control);
                    MessageBox.Show("OK");
    
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                }    
                }
            }
