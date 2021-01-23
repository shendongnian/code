    public partial class frmPlant : Form
    {
         string gSelectedPlant;
         bool ignoreSelChg = false;  // <- added this bool    
         private void frmPlant_Load(object sender, EventArgs e)
         {
                dataGridView1.AutoGenerateColumns = true;
                dataGridView1.DataSource = bindingSource1;
                FillData();
    
                dataGridView1.DataMember = "Table";
         }
         private void FillData()
         {
                ignoreSelChg = true; // <- set the bool, SelectionChanged won't do anything now
                ds = _DbConnection.returnDataSet(_SQlQueries.SQL_PlantSelect);
                bindingSource1.DataSource = ds.Tables[0];
         }
         public DataSet returnDataSet(string txtQuery)
         {
                conn.Open();
                sqlCommand = conn.CreateCommand();
                DB = new SQLiteDataAdapter(txtQuery, conn);
                DS.Reset();
                DB.Fill(DS);
                conn.Close();
                return (DS);
         }
         private void dataGridView1_Selectionchanged(object sender, EventArgs e)
         {
                if (ignoreSelChg)  // <- don't do anything before DataBindingComplete
                    return;
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    gSelectedPlant = dataGridView1.SelectedRows[0].Cells["PlantId"].Value.ToString();
                }
         }
    
         private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
            {
                int selectedIndex;
                if (!string.IsNullOrEmpty(gSelectedPlant) && e.ListChangedType == ListChangedType.Reset)
                {
                    ignoreSelChg = false; // <- reset the bool, SelectionChanged get executed again
                    if (ds.Tables.Count > 0)
                    {
                        selectedIndex = bindingSource1.Find("PlantId", gSelectedPlant);
                        if (selectedIndex <= 0)
                            selectedIndex = 0;
                        dataGridView1.Rows[selectedIndex].Selected = true;
                    }
                    else
                    {
                        gSelectedPlant = string.Empty;
                    }
                }
            }
        }
