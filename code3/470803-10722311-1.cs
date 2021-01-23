    // ... again create XmlTextReader and read to rawnode, then:
    // here we start
    int buflen = 15;
    char[] buf = new char[buflen];
    StringBuilder sb= new StringBuilder("<",20);
    
    //get start tag and attributes    
    string tagname=r.Name;
    sb.Append(tagname);
    bool hasAttributes = r.MoveToFirstAttribute();
    while (hasAttributes)
    {
        sb.Append(" " + r.Name + @"=""" + r.Value + @"""");
        hasAttributes = r.MoveToNextAttribute();
    }
    sb.Append(@">");
    r.MoveToContent();
        
    //get raw inner data	
    int cnt;
    while ((cnt = r.ReadChars(buf, 0, buflen)) > 0)
    {
        if ( cnt<buflen )
            buf[cnt]=(char)0;
        sb.Append(buf);
    }
    	
    //append end tag    
    sb.Append("</" + tagname + ">");
    	
    // get it out
    string output = sb.ToString();
