    XmlDocument XmlFoo = null;
    bool loading = false;
    try{
        ..
        XmlFoo = new XmlDocument();
        loading = true;
        XmlFoo.LoadXml(SomeXml);
        loading = false;
        ..
    }
    catch (Exception ex){
    
       if(loading)
       {
          //something went wrong while loading XML
       }   .. 
    }
