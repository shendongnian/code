    Create PROCEDURE [dbo].[PmSPValidate]
    @a varchar(10)
    
    AS
    BEGIN
    (SELECT AcctDsc,AcctAge 
    FROM dbo.tblCoa 
    WHERE AcctNo >= @a)
    
    END
    
    Code of C# :
    
     private void btnThirdTrial_Click(object sender, EventArgs e)
            {
                string connetionString = null;
                SqlConnection connection;
                SqlDataAdapter adapter;
                SqlCommand command = new SqlCommand();
                SqlParameter param;
                DataSet ds = new DataSet();
    
                int i = 0;
    
                connetionString = "Data Source=FIN03;Initial Catalog=CmsTest;Integrated Security=True";
    
                connection = new SqlConnection(connetionString);
    
                connection.Open();
                command.Connection = connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.PmSPValidate";
    
                param = new SqlParameter("@a",Account.Text.ToString ());
                param.Direction = ParameterDirection.Input;
                param.DbType = DbType.String;
                command.Parameters.Add(param);
    
                adapter = new SqlDataAdapter(command);
                adapter.Fill(ds);
                
                for (i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                {
                    MessageBox.Show(" Name " + ds.Tables[0].Rows[i][0].ToString() + "  Age " + ds.Tables[0].Rows[i][1].ToString());
                  
                }
    
                connection.Close();
    
            }
