    // Data class to set data in Form2
    internal class Form2Data
    {
        public string Name;
        ...
    }
    ...
    internal class Form2 : Form
    {
        public static DialogResult ShowDlg ( Form2Data oData )
        {
            Form2 oFrm = new Form2 ();
            oFrm.SetData ( oData );
            DialogResult nResult = oFrm.ShowDialog ();
            if ( nResult == DialogResult.Ok )
                oFrm.GetData ( oData );
            return ( nResult );
        }
        private void SetData ( Form2Data oData )
        {
            // Set control values here
        }
        private void GetData ( Form2Data oData )
        {
            // Read control values here
        }
    }
    ...
    // You call this as such:
    Form2Data oData = new Form2Data ();
    oData.Name = "...";
    DialogResult nResult = Form2.ShowDlg ( oData );
    // after the call, oData should have updated values from Form2
    if ( nResult == DialogResult.Ok )
    {
        // show your next form in a similar pattern - set up data
        // call form's static method to pass it and then wait for
        // the form to finish and return with updated data.
    }
