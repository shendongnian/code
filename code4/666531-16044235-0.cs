    foreach (string k in e.Values.Keys)
    {
        if (e.Values[k] != null && !String.IsNullOrEmpty(e.Values[k].ToString()))
        {
            System.Type objectType = roster.GetType();
            PropertyInfo[] p = objectType.GetProperties();
            foreach (PropertyInfo pi in p)
            {
                if (pi.Name == k)
                {
                    System.Type t = pi.PropertyType;
                    pi.SetProperty(e.Values[k].ToString(), roster);
                    break;
                }
                else if (pi.Name.Contains("Reference"))
                {
                    var name = pi.Name.Left("Reference");
                    var keys = k.Split('.');
                    var entityName = keys[0];
                    var prop = keys[1];
                    if (name == entityName )
                    {
                        var val = e.Values[k].ToString();
                        switch (pi.Name)
                        {
                            case "Entity2Reference":
                                Entity1.Entity2Reference.EntityKey = new EntityKey("MyEntities." + entityName + "s", prop, val);
                                break;
                            case "Entity3Reference":
                                Entity1.Entity3Reference.EntityKey = new EntityKey("MyEntities." + entityName + "s", prop, val);
                                break;
                            case "Entity4Reference":
                                Entity1.Entity4Reference.EntityKey = new EntityKey("MyEntities." + entityName + "s", prop, Int64.Parse(val));
                                break;
                        }
                    }
                }
            }
        }
    }
