    Type tp = Type.GetType(Namespace.class + "," + n.Attributes["ProductName"].Value + ",Version=" + n.Attributes["ProductVersion"].Value + ", Culture=neutral, PublicKeyToken=null");
    if (tp != null)
    {
        object o = Activator.CreateInstance(tp);
        Control x = (Control)o;
        panel1.Controls.Add(x);
    }
