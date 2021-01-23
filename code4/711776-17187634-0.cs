    protected void DeleteStuff(object sender, GridViewDeleteEventArgs e)
    {
        if (CheckAccess())
        {
            deleting.Visible = true;
            System.Threading.Thread.Sleep(5000);   
            deleting.Visible = false;
        }
        else
        {
            Dispatcher.BeginInvoke((Action) (() => DeleteStuff(sender, e)));
        }
    }
