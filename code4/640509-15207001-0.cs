    Person person = GetPerson();
     
    
        using (FileStream fs = File.Open(@"c:\person.json", FileMode.CreateNew))
        using (StreamWriter sw = new StreamWriter(fs))
        using (JsonWriter jw = new JsonTextWriter(sw))
        {
          jw.Formatting = Formatting.Indented;
         
          JsonSerializer serializer = new JsonSerializer();
          serializer.Serialize(jw, person);
        }
    
