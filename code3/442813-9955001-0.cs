    SqlCommand comm = new SqlCommand("INSERT INTO desg VALUES (@txtsno, @txtdesg, @txtbasic)", connection);
    your_db.Open();
    try {
        comm.Parameters.AddWithValue("@txtsno", txtsno.Text.Trim());
        comm.Parameters.AddWithValue("@txtdesg", txtdesg.Text.Trim());
        comm.Parameters.AddWithValue("@txtbasic", txtbasic.Text.Trim());
        comm.ExecuteNonQuery();
        comm.Dispose();
        comm = null;
    }
    catch(Exception ex)
    {
        throw new Exception(ex.ToString(), ex);
    }
    finally
    {
        your_db.Close();
    }
