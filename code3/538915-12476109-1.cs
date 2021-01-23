    var jFoo = JObject.Parse(data);
    foreach (JToken child in jFoo.Children())
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
