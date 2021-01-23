    private AutoCompleteStringCollection source  = new AutoCompleteStringCollection();
    			
    			private void loadAutoCompleteStringCollection();
    			{
    				string cnn = (@"Data Source=TaLy-PC;Initial Catalog=dbMarketi;Integrated Security=True;Pooling=False");
    				source.Clear();
    				SqlConnection connection = new SqlConnection(cnn.ToString());
    				SqlCommand command = new SqlCommand("Select Barcode FROM tblDepo", connection);
    
    				try
    				{
    					connection.Open();
    					{
    						SqlDataReader drd = command.ExecuteReader();
    						while (drd.Read())
    						{
    							// this.comboBoxEx1.Items.Add(drd.GetString(0).ToString());
    							source.AddRange(new string[] { drd.GetString(0).ToString() });
    						}
    					}
    				}
    				catch (Exception ex)
    				{
    					MessageBox.Show(ex.Message.ToString());
    				}
    				finally
    				{
    				    connection.Close();
    				}
    			}
    			
    			private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
    			{
    				TextBox dgvEditBox = e.Control as TextBox;
    				if (dataGridView1.CurrentCell.ColumnIndex == 1)
    				{
    					if (dgvEditBox != null)
    					{
    						dgvEditBox.AutoCompleteMode = AutoCompleteMode.Suggest;
    						dgvEditBox.AutoCompleteCustomSource = source;
    						dgvEditBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
    					}
    				}
    			}
    			
    			//If you want to reload the AutoCompleteStringCollection
    			private void button1_Click(object sender, System.EventArgs e)
    			{
    				loadAutoCompleteStringCollection();
    			}
