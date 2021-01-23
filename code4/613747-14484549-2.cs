    public void RecursivelyDoOnControls(DoSomethingWithControl aDel, Control aCtrl)
    {
        aDel(aCtrl);
        foreach (Control c in aCtrl.Controls)
        {
            RecursivelyDoOnControls(aDel, c);
        }
    }
