    Return Value
    Type: System.Object
    A Color that represents the converted text.
------
    ColorConverter c = new ColorConverter();
    Color color = (Color)c.ConvertFromString("#FFF");
    Console.WriteLine(color.Name);
