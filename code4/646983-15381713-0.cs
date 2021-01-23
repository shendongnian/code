    private BindingSource bindingSource = null;
    private SqlDataAdapter sqlDataAdapter = null;
    DataTable dataTable=null;
    private void Form_Load(object sender, EventArgs e)
    {
         dataTable = new DataTable();
         sqlDataAdapter.Fill(dataTable);//Fill Data To bind Datagridview
         bindingSource = new BindingSource();
         bindingSource.DataSource = dataTable;
         dataGridViewTrial.DataSource = bindingSource;
    }
    
    private void btnSave_Click(object sender, EventArgs e)
    {
         try
           {
               sqlDataAdapter.Update(dataTable);
           }
           catch (Exception exceptionObj)
              {
                 MessageBox.Show(exceptionObj.Message.ToString());
              }
    }
