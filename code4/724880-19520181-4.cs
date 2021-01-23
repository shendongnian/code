     protected void Button1_Click(object sender, EventArgs e)
        {
    //in 'sURL' paste WCF service link up to .svc and write -> /user_register/Prateek/1234 
    //here user_register is service method path and Prateek and 1234 are parameters that will enter to database 
            string sURL = "http://localhost:49271/Service1.svc/user_register/Prateek/1234";
        
            WebRequest wrGETURL;
            wrGETURL = WebRequest.Create(sURL);
            wrGETURL.Method = "POST";
            wrGETURL.ContentType = @"application/json; charset=utf-8";
            HttpWebResponse webresponse = wrGETURL.GetResponse() as HttpWebResponse;
    
            Encoding enc = System.Text.Encoding.GetEncoding("utf-8");
            // read response stream from response object
            StreamReader loResponseStream = new StreamReader(webresponse.GetResponseStream(), enc);
            // read string from stream data
            strResult = loResponseStream.ReadToEnd();
            // close the stream object
            loResponseStream.Close();
            // close the response object
            webresponse.Close();
            // assign the final result to text box
            Response.Write(strResult);
        }
