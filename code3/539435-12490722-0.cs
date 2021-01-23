    catch(Exception x)
    {
        var s = x.Message;
        if ( x.InnerException!=null )
        {
            s += Environment.NewLine + x.InnerException.Message;
        }
        MessageBox.Show(s);
    }
