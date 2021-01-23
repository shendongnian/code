    finally
    {
        //Close the connection
        if (conn.State != ConnectionState.Closed)
        {
            //Close the connection
        }
        //Close the window
        DialogResult = DialogResult.OK;
    }
