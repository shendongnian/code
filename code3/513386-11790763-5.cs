    using (System.Data.SqlClient.SqlConnection cn = 
                        new System.Data.SqlClient.SqlConnection(@"Data Source=ASHWINI-LAPY\SQLEXPRESS;Initial Catalog=complete;Integrated Security=True;Pooling=False"+
                            "Integrated Security=True"))
    {
           using (System.Data.SqlClient.SqlCommand cmd= new System.Data.SqlClient.SqlCommand("IsBarcodeCheckAndInsert", cn))
           {
                cmd.CommandType=CommandType.StoredProcedure ; 
                SqlParameter parm= new SqlParameter("@BarCode", cn",SqlDbType.VarChar) ;
                parm.Value="ALFKI";
                parm.Size=25;  
                parm.Direction =ParameterDirection.Input ;
                cmd.Parameters.Add(parm);
                SqlParameter parm2=new SqlParameter("@IsExists",SqlDbType.Int);
                parm2.Direction=ParameterDirection.Output;
                cmd.Parameters.Add(parm2); 
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                int IsExists = Convert.ToInt32(cmd.Parameters["@IsExists"].Value.ToString());
                if(IsExists ==0)
                     MessageBox.Show("Barcode Already Exists !!"); 
                else if(IsExists ==1)
                     MessageBox.Show("Barcode not Exists And Inserted In DataBase!!"); 
    
          }
    }
