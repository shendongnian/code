    private void MenuItem_Click(object sender, EventArgs e)
    {
        var id = (String) ((MenuItem))sender.Tag;
        // use reflection:
        Type yourType= yourObject.GetType();
        MethodInfo theMethod = thisType.GetMethod(String.Format("MenuOption_{0}", id)); 
        theMethod.Invoke(this, null);
    }
    public void MenuOption_X
    {
     ...
    }
    public void MenuOption_XX
    {
     ...
    }
