    protected void login_Click(object sender, EventArgs e)
        {
            OleDbConnection connect = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\\Users\\parodeghero\\Documents\\Visual Studio 2010\\Projects\\Project3\\Project3\\App_Data\\QA.mdb;Persist Security Info=True");
            //set up connection string
            OleDbCommand command = new OleDbCommand("select * from Employee where Login=@login", connect);
            OleDbParameter param0 = new OleDbParameter("@login", OleDbType.VarChar);
    
            param0.Value = employeeID.Text;
            command.Parameters.Add(param0);
            
            try
            {
                connect.Open();
            }catch(Exception err){ Debug.WriteLine(err.Message);}
    
            //middle tier to run connect
            OleDbDataAdapter da = new OleDbDataAdapter(command);
    
            DataSet dset = new DataSet();
    
            da.Fill(dset);
