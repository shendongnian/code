        while (reader.Read())
        {
            switch (reader.Name)
            {
                case "GUID":
                    id = reader.ReadString();
                    break;
                case "Title":
                    name = reader.ReadString();
                    break;
                case "Type":
                    type = reader.ReadString();
                    break;
            }              
            htmlstring += "<" + type + " id=" + id + " value=" + name + "/>" + name + "</" + type + ">";
        }
