    public void updateSupplierInformation(string id, string name, string balance, string place, string address, string phone, string bankname, string bankbranch, string accountno)
        {
           try
           {
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
    
            SqlCommand NewCmd = conn.CreateCommand();
            NewCmd.Connection = conn;
            NewCmd.CommandType = CommandType.Text;
            NewCmd.CommandText = " update supplier set " + " ID = " + "'" + id + "'" + " , NAME = " + "'" + name + "'" + " , BALANCE = " + "'" + balance + "'" + " , PLACE = " + "'" + place + "'" + "  , LOCATION = " + "'" + address + "'" + ",  PHONE = " + "'" + phone + "'" + " , BANK_NAME = " + "'" + bankname + "'" + " , BANK_BRANCH = " + "'" + bankbranch + "'" + ", ACCOUNT_NO = " + "'" + accountno + "'" + " where ID = " + "@id";
            NewCmd.Parameters.AddWithValue("@id",id);
            int a=NewCmd.ExecuteNonQuery(); 
            conn.Close();
            if(a==0)
              //Not updated.
            else
              //Updated.
            }
            catch(Exception ex)
             {
             // Not updated
             }
        }
