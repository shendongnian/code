    try
    { 
        request.ContentLength = bytes.Length;   
        st = request.GetRequestStream();
        st.Write(bytes, 0, bytes.Length);         
    }
    catch (Exception ex)
    {
        MessageBox.Show(ex.Message);
        return 1;
    }
    finally
    {
        if (st != null)
        {
            st.Close();
        }
    }
