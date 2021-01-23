    public void GenericHandler(object sender, EventArgs e)
    {
        if (e is MouseEventArgs)
        {
            var mouseArgs = e as MouseEventArgs;
            // .. process this case
        }
        else if (e is ....)
    }
