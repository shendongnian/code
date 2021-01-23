    foreach(HtmlNode node in resultContainer)
    {
        //check node type
        switch(node.Name)
        {
            case "div":
            {
                break;
            }   
            case "p":
            {
            }
            ///....etc
        }
        //get id
        String id = node.Attributes["id"].Value;
        
        //get class
        String class = node.Attributes["class"].Value;
    }
