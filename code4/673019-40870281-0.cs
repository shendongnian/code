    protected void MyMethodOnServerSide(object source, ServerValidateEventArgs args)
    {
         if (string.IsNullOrEmpty(mytxt1.Text) &&
                string.IsNullOrEmpty(mytxt2.Text))
                {
                    args.IsValid = false;
                    return;
                }
    
                args.IsValid = true;
    }
