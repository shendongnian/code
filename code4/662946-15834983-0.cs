    int i=0;
    foreach (Control c in panel1.Controls)
    {
        if (c is UserControl1) 
        {
            if (((UserControl)c).Selected)
            {
                 TextBox dynTxtBox = (TextBox)c.Controls["txtBox" + i];
                 txtSimple.Text= dynTxtBoxe.Text;
            }
        }
        i++;
    }
