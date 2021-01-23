      catch (SqlException ex)
      {
          // Handle the Sql Exception code
      }
      catch (Exception ex)
      {
          // Handle the Normal Exception code
      }
      finally
      {
         sqlconn.Close();
      }
