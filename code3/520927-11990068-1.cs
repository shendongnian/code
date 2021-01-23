    request.ContentLength = bytes.Length;   
    using(var st = request.GetRequestStream())
    {
        st.Write(bytes, 0, bytes.Length);         
        st.Close();
    }
    
