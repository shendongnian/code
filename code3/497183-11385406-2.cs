    private void inetConvert() {  
        private const BUFFER_SIZE = 1024;
        byte[] buf = new byte[BUFFER_SIZE];  
        string result;  
        string xeString = String.Format("http://www.xe.com/ucc/convert.cgi?Amount=1&From={0}&To={1}", srcCurrency, dstCurrency);  
        System.Net.WebRequest wreq = System.Net.WebRequest.Create(new Uri(xeString));  
        
        // VERY IMPORTANT TO CLEAN UP RESOURCES FROM ANY OBJECT THAT IMPLEMENTS IDisposable
        using(System.Net.WebResponse wresp = wreq.GetResponse()) 
        using(Stream respstr = wresp.GetResponseStream())
        {
          int read = respstr.Read(buf, 0, BUFFER_SIZE); // Error  
          result = Encoding.ASCII.GetString(buf, 0, read);   
          curRateLbl.Text= result;  
        }
    }  
