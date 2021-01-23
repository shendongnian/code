    delegate void addtoValProg();
    addtoValProg myDelegate;
    myDelegate = new addtoValProg(invokeControl);
    private void GeneraListaCartelle()
    {
        try
        {
            //... some operation ....
        }
        catch (Exception err)
        {
            invokeControl();
        }
    }
    private void invokeControl()
    {
        if (this.InvokeRequired)
        {
            this.Invoke(this.myDelegate);
        }
        else
        {
            txtErrors.AppendText(err.Message);
            txtErrors.Update();
        }
    }
