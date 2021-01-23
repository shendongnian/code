     Person p1 = new Person() { name = "Tom" };
            Person p2 = new Person() { name = "Ed" };
            List<Person> lijst = new List<Person>();
            lijst.Add(p1);
            lijst.Add(p2);
            persons = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(lijst);
