    public void ChangeText(string classtype, string name, string text)
    {
        var type = Type.GetType(classtype);
        type.GetProperty("Text").SetValue(objects[name], text);
    }
