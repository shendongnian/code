    foreach(Control c in mainForm.Controls.OfType<Control>().Reverse())
    {
        if (c is Panel)
        {
          mainForm.Controls.Remove(c);      
        }
    }
