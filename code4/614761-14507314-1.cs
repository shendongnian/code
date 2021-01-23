    using System.Reflection;
    
    // your TabControl will be defined in your designer
    TabControl tc;
    // as will your original TabPage
    TabPage tpOld = tc.SelectedTab;
    TabPage tpNew = new TabPage();
    foreach(Control c in tpOld.Controls)
    {
        Control cNew = (Control) Activator.CreateInstance(c.GetType());
        PropertyDescriptorCollection pdc = TypeDescriptor.GetProperties(c);
        foreach (PropertyDescriptor entry in pdc)
        {
            object val = entry.GetValue(c);
            entry.SetValue(cNew, val);
        }
        tpnew.Controls.Add(cNew);
    }
    tc.TabPages.Add(tpNew);
