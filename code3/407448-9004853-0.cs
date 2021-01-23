    Type type = myField.GetType();
    if (type == MyDataField.GetType())
    {
        …
    }
    else if (type.ToString() == "MyDataField")
    {
        …
    }
    else
    {
        …
    }
