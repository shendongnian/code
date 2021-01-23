       void getAllProperties(JToken children)
        {
            foreach (JToken child in children.Children())
            {
                var property = child as JProperty;
                if (property != null)
                {
                    Console.WriteLine(property.Name + " " + property.Value);//print all of the values
                }
                getAllProperties(child);
            }
        }
