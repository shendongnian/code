    public string previousEmail   //Global variable - gets value from other source
    public string FindEmailSubscription()
    {
       try
       {
          string email = null;
          using (DataAccess data = new DataAccess())
          {            
              data.Execute(
                   "SELECT EmailAddress FROM table " +
                    "WHERE EmailAddress=@EmailAddress; ",
                    new SqlParameter("@EmailAddress", previousEmail));
              if (data.Read())
                  email = data.GetValue<string>(0);
          }
          return email;
       }
       catch (Exception ex)
       {
           MessageBox.Show(ex);
       }
    }
