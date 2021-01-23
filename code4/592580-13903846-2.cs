    public void ChangeText(string name, string text)
    {
        var type = objects[name].GetType();
        type.GetProperty("Text").SetValue(objects[name], text);
    }
