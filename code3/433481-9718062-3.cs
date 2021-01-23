        String baseUri = “your service URI";
        WebClient wc = new WebClient();
        
        public MainPage()
        {
            InitializeComponent();
        wc.DownloadStringCompleted += new DownloadStringCompletedEventHandler     (wc_downloadstringcompleted);
        // event handler that will handle the ‘downloadstringsompleted’ event
        
               wc.DownloadStringAsync(new Uri(baseUri));    
        //   this method will download your string URI asynchronously    
        
        }
       
    
     void wc_downloadstringcompleted(Object sender, DownloadStringCompletedEventArgs e)
        {
                // method will get fired after URI download completes
                 // writes your every code here
                 // this is to parse the data:  
    
                using (XmlReader reader = XmlReader.Create(new StringReader(xmlString)))
                {         
                    while (reader.Read())
                    {
                        switch (reader.NodeType)
                        {
                            case XmlNodeType.Element:
                                if (reader.Name = "userId")
                                         string str1 = reader.value();
                                break;
                        }
                    }
                }
                
            name.text = str1;
      }
