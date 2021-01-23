    foreach (Control c in txt) // txt???
    {
        UserControl1 uc = c as UserControl1;
        if (uc != null) 
        {
            if (uc.Selected) txtSimple.Text= uc.Text ;
        }
    }
