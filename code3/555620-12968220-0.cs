        string theSqlConnStr = "data source=TheSource;initial catalog=TheCatalog;persist security info=True;user id=TheUserId;password=ThePassword";
        SqlConnection theSqlConnection = new SqlConnection(theConnectionString);
        EntityConnectionStringBuilder theEntyConnectionBuilder = new EntityConnectionStringBuilder();
        theEntyConnectionBuilder.Provider = "System.Data.SqlClient";
        theEntyConnectionBuilder.ProviderConnectionString = theConnectionString;
        theEntyConnectionBuilder.Metadata = @"res://*/";
        using (EntityConnection theConnection = new EntityConnection(theEntyConnectionBuilder.ToString()))
        {
            theConnection.Open();
            theET = null;
            try
            {
                theET = theConnection.BeginTransaction();
                DataEntities1 DE1 = new DataEntities1(theConnection);
                //DE1 do somethings...
                DataEntities2 DE2 = new DataEntities2(theConnection);
                //DE2 do somethings...
                DataEntities3 DE3 = new DataEntities3(theConnection);
                //DE3 do somethings...
                theET.Commit();
            }
            catch (Exception ex)
            {
                if (theET != null) { theET.Rollback(); }
            }
            finally
            {
                theConnection.Close();
            }
        }
