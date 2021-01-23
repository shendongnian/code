    //find the Reponses with regex
    MatchCollection  matches = Regex.Matches(inputString, "<Response>(.)+</Response>");
    
    XmlSerializer serializer = new XmlSerializer(typeof(Response));
    
    List<Response> entityList = new List<Response>();
    
    
    //Deserialize the reponses
    foreach (Match item in matches)
    {
        using(System.IO.TextReader rdr = new StringReader(item.Value))
        {
            Response entity = (Response)serializer.Deserialize(rdr);
            entity.Line = item.Value;
            entityList.Add(entity);
        }
    }
    
    //now you have real objects which you can treat however you want. Example just a loop or linq or whatever
    for (int i = 0; i < entityList.Count; i++)
    {
        if (i > 0 && entityList[i - 1].ReturnCode == entityList[i].ReturnCode)
            Console.Out.WriteLine("--DO--");
        else
            Console.Out.WriteLine(entityList[i].Line);
    }
