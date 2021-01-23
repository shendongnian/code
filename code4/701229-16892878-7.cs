    GUI.Printing preview = null;
    foreach (Form form in Application.OpenForms)
    {
        if (form.GetType() == typeof(GUI.Printing))
        {
            preview = (GUI.Printing)form;
            break;
        }
    }
    
    if (preview == null)
    {
        return;
    }
    preview.Show();
    preview.Preview();
