    string[] lines = File.ReadAllLines(path);
    foreach (string line in lines)
    {
        Contact contact = new Contact();
        string[] parts = line.Split('$');
        foreach (string part in parts)
        {
            string[] temp = part.split('=');
            string propName = temp[0];
            string propValue = (temp.Length > 1) ? temp[1] : "";
            contact.GetType().GetProperty(propName).SetValue(contact, propValue, null);
        }
    }
