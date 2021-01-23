    public void ChangeText(string name, string text)
    {
        dynamic item = objects[name];
        item.Text = text;
    }
