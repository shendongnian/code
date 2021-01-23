    String apa1 = @"texttest: text test
                    test text test text
    
                    Lorem ipsum dolor sit
                    amet, consectetur 
                    adipiscing: elit. 
                    Curabitur dolor lectus, 
                    cursus ac placerat vitae, 
                    volutpat sit: amet lacus.";
    String apa2 = string.Empty;
    String tmp = String.Copy(apa1);
    StringReader strReader = new StringReader(tmp );
    String line = strReader.ReadLine();
    while(!string.IsNullOrEmpty(line))
    {
        apa2 += line;
        line = strReader.ReadLine();
    }
   
    apa1 = strReader.ReadToEnd();
