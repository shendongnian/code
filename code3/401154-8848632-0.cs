    static void myMethod( int i)
    {
        int j = 0;
        try
        {
                                            
            string url = String.Format("http://www.google.com");
            WebRequest wr = WebRequest.Create(url);
            using(HttpWebResponse response = (HttpWebResponse)wr.GetResponse())
            using(Stream responseStream = wr.GetResponseStream())
            {
                //handle response / response stream
            }                
            MessageBox.Show("end");  //this won't scale!!!
        }
        catch (Exception ex)
        {
            MessageBox.Show(j.ToString() + "   " + ex.Message);
        }
    }
