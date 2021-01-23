    var list = new List<CheckBox>();
    foreach(var control in Controls)
    {
        var checkBox = control as CheckBox;
        if(checkBox != null)
        {
            list.Add(checkBox);
        }
    }
    var checkBoxArray = list.ToArray();
