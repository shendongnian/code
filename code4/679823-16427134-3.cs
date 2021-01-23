    public class DALimp : iDAL
    {
        string connStr;
        SqlConnection conn;
        SqlCommand cmd;        
        DataSet ds;
        SqlDataAdapter da;
        public DALimp()
        {
            connStr = ConfigurationManager.ConnectionStrings["StoreDBConnectionString"].ConnectionString;
            conn = new SqlConnection(connStr);
            
        }
    
        public DataSet GetOrderDetailsDS(int oId)
        {
            var select = "SELECT * FROM tblOrders WHERE orderId='"+oId+"'";
            ds = new DataSet();
            cmd = new SqlCommand(select, conn);
            try
            {
                conn.Open();
                ds.Load(cmd.ExecuteReader(), LoadOption.OverwriteChanges, "tblOrders");
            }
            catch (Exception ex)
            { throw ex;  }
            finally
            { conn.Close();  }
            return ds;
        }
        public DataTable GetProductTable()
        {
            cmd = new SqlCommand("SELECT * FROM tblProducts", conn);
            da = new SqlDataAdapter("SELECT * FROM tblorderLines", conn);
            da.InsertCommand = new SqlCommand("INSERT INTO tblorderLines (ordrNumid,ordrPrdctid,ordrQuantity) Values(@oid,@pid,@qnt)", conn);
            da.InsertCommand.Parameters.Add("@oid", SqlDbType.Int, 0, "ordrNumid");
            da.InsertCommand.Parameters.Add("@pid", SqlDbType.Int, 0, "ordrPrdctid");
            da.InsertCommand.Parameters.Add("@qnt", SqlDbType.SmallInt, 0, "ordrQuantity");
            try
            {
                conn.Open();
                ds.Load(cmd.ExecuteReader(), LoadOption.OverwriteChanges, "tblProducts");
                da.Fill(ds, "tblorderLines");
                ds.Relations.Add("orderdetails", ds.Tables["tblOrders"].Columns["orderId"], ds.Tables["tblorderLines"].Columns["ordrNumid"], false);
            }
            catch (Exception ex)
            { throw ex;   }
            finally
            { conn.Close();  }
            return ds.Tables["tblProducts"];
        }
      
        public bool SaveChanges()
        {
            try
            {
                if (ds.Tables["tblorderLines"].GetChanges() == null)
                    return false;
                 var update = "UPDATE tblorderLines SET ordrNumid= @oni, ordrPrdctid= @opi, ordrQuantity= @oq WHERE ordritmId= @oii";
                var cmd = new SqlCommand(update, conn);
                
                cmd.Parameters.Add("@oni", SqlDbType.Int, 4, "ordrNumid");
                cmd.Parameters.Add("@opi", SqlDbType.Int, 4, "ordrPrdctid");
                cmd.Parameters.Add("@oq", SqlDbType.SmallInt, 2, "ordrQuantity");
                cmd.Parameters.Add("@oii", SqlDbType.BigInt, 8, "ordritmId").SourceVersion = DataRowVersion.Original;
                da.UpdateCommand = cmd;
                da.Update(ds, "tblorderLines");
                return true;
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
