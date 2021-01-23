    Hashtable hashTable = new Hashtable();
    int intVal;
    string prevColumnName = "";
    while (reader.Read())
    {
        if (reader.NodeType == XmlNodeType.Element)
        {
            element = reader.Name;
        }
        else if (reader.NodeType == XmlNodeType.Text)
        {
            switch (element.ToLower())
            {
                case "column":
                    prevColumnName = reader.Value;
                    hashTable.Add(reader.Value, null);
                    break;
                case "int":
                    if (int.TryParse(reader.Value, out intVal))
                        hashTable[prevColumnName] = intVal;
                    break;
                case "string":
                    hashTable[prevColumnName] = reader.Value;
                    break;
            }
        }
    }
