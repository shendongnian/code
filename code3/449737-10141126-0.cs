    using(SqlConnection conn = new SqlConnection())
    {
        conn.Open();
        // Do what you please here        
    }
    catch (Exception ex)
    {
        // Write error to file
        File.Append(..., 
            DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") + " " + 
            ex.Message);
    }
    finally { conn.Close(); }
