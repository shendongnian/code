        public static string ReturnProperty(object ob, string prop)
        {
            if (ob is ExpandoObject)
            {
                return ((ExpandoObject)ob).Single(e => e.Key == prop).Value.ToString();
            }
            Type type = ob.GetType();
            PropertyInfo pr = type.GetProperty(prop);
            return pr.GetValue(ob, null).ToString();
        }
        //--
        dynamic dyna = new ExpandoObject();
        dyna.Name = "Element";
        Console.WriteLine(ReturnProperty(dyna, "Name"));
        
