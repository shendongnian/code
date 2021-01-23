    var myHttpWebRequest = (HttpWebRequest)WebRequest.Create("http://www.contoso.com"); 
    //increase this number if there are more then one redirects. 
    myHttpWebRequest.MaximumAutomaticRedirections = 1;
    myHttpWebRequest.AllowAutoRedirect = true;
    var myHttpWebResponse = (HttpWebResponse)myHttpWebRequest.GetResponse();    
    
    // here you specify the path to the file. The path in this example is : image.jpg
    // if you want to store it in the application root use:
    // AppDomain.CurrentDomain.BaseDirectory + "\\image.jpg"
    using (var sw = new BinaryWriter(File.Open("image.jpg", FileMode.OpenOrCreate)))
    {
        using (var br = new StreamReader(myHttpWebResponse.GetResponseStream()))
        {
            sw.Write(br.ReadToEnd());
        }
    }
