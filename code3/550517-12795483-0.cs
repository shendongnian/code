    private void MenuItem_Click(object sender, EventArgs e)
    {
        var id = (int) ((MenuItem))sender.Tag;
        // use reflection:
        Type yourType= yourObject.GetType();
        MethodInfo theMethod = thisType.GetMethod(String.Format("MenuOption_{0}", id)); 
        theMethod.Invoke(this, null);
    }
