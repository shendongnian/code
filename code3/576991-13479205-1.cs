    public void RecursivelyClear(Control parent)
    {
        for each (var theControl in parent.Controls)  {
            if (theControl is TextBox)
                // your code here ...
            if (theControl.HasControls)
                RecursivelyClear(theControl);
        }
    }
