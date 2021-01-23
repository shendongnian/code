    var field = item.GetType().GetField(item.ToString());
    var display = field.GetCustomAttributes(typeof(DisplayAttribute), true).FirstOrDefault() as DisplayAttribute;
    if (display != null)
    {
        label.SetInnerText(display.Name);
    }
    else
    {
        label.SetInnerText(item.ToString());
    }
