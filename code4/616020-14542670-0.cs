    public partial class FrmDatabaseConnection : Form
    {
    	// Connection, Adapter, DataTable, CommandBuilder, Bindingsource and command
    	private SqlDataAdapter adap;
    	private DataTable dataTable;
    	private SqlCommandBuilder commandBuilder;
    	private string sqlCommand = "SELECT * FROM store_adj_note_detail_1";
    	private SqlConnection conDB = new SqlConnection();
    
    	//To open connection and fill datagridview1
    	private void establishConnection()
    	{
    		try
    	            {
                        conDB.ConnectionString = "Data Source=localhost;Initial Catalog=ScratchCardSystem2;Integrated Security=True;pooling=true";
    	                conDB.Open();
    	
    	                // Set adapter, commandbuilder, datatable and bindingsource
    	                adap = new SqlDataAdapter(sqlCommand, conDB.ConnectionString);
    	                commandBuilder = new SqlCommandBuilder(adap);
    	                bindSrc = new BindingSource();
    	                dataTable = new DataTable();
    	
    	                // Fill it!
    	                adap.Fill(dataTable);
    	                dataGridView1.DataSource = bindSrc;
    	                bindSrc.DataSource = dataTable;
    	
    	                
    	            }
    	            catch (Exception ex)
    	            {
    	                MessageBox.Show("Unable to Open database, " + ex.Message,);
    	                conDB.Close();
    	            }
    	
    	}
    	
    	private bool saveToDatabase()
    	{
    		try
                    {
                        adap.Update((DataTable)bindSrc.DataSource);
    		    }
    		catch (Exception ex)
                    {
                        MessageBox.Show("Unable to Update database, " + ex.Message);
                        return false;
                    }
    
    	}
    
    	
    }
