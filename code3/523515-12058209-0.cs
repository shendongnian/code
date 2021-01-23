    foreach (var control in myForm.Controls)
    {
        string name = control.GetType().Name;
        if (name  == "TextBox" || name  == "Label" || name  == "Button")
        {
            control.MouseDown += MyMouseDown;
        }
    } 
