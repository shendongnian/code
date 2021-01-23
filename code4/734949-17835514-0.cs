    private void performSQL() 
    {
       string result = "select sum(purprice) from localcollection";
       using (SqlCeConnection myconn = new SqlCeConnection("ConnectionString"))
       using (SqlCeCommand showresult = new SqlCeCommand(result, myconn))
       {
          try
          {
              myconn.Open();
              label4.Text = showresult.ExecuteScalar().ToString();
                   
          }catch(System.Exception ex)
          {
              MessageBox.Show(ex.ToString());
              // or log exception how ever you prefer
          }finally
          {
              //the finally ensures your connection gets closed
              myconn.Close();
          }
       }
    }
