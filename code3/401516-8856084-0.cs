    var o = JObject.Parse(yourJsonString);
    
    foreach (JToken child in o.Children())
    {
        foreach (JToken grandChild in child)
        {
            foreach (JToken grandGrandChild in grandChild)
            {
                var property = grandGrandChild as JProperty;
                
                if (property != null)
                {
                    Console.WriteLine(property.Name + ":" + property.Value);
                }
            }
        }
    }
