    // string to sort / cut
    string str ="
    Description: 
    TEXT,TEXT,TEXT,TEXT,TEXT,TEXT
    
    Note:
    TEXT1,TEXT1,TEXT1,TEXT1,TEXT1
    
    Description: 
    TEXT2,TEXT2,TEXT2,TEXT2,TEXT2
    
    Note:
    TEXT3, TEXT3, TEXT3, TEXT3, TEXT3";
    
    //List of string to retrieve tags descriptions
    List<String> tagsDescriptions = new List<String>();
    //List of string to retrieve tags notes
    List<String> tagsNotes = new List<String>();
    
    // Read str and get only the Description content 'sample'
    using (StringReader reader = new StringReader( text )) 
                { 
                    string line; 
                    bool getContent = false;
                    while ((line = reader.ReadLine()) != null) 
                    { 
                        if(getContent)
                        {
                            tagsDescription.Add(line);
                            getContent = false;
                        }
                        if(line.contain("Description"))
                        {
                            getContent = true;
                            
                        }
                    } 
                } 
