    protected void BtnMybutton_click( Object sender, EventArgs e)
    {
        Button Mybutton = (Button) sender;
        GridViewRow row = (GridViewRow) MyButton.NamingContainer;
        CheckBox ChkTest = (CheckBox) row.FindControl("ChkTest");
        HidenFiekd HdfValue = (HidenField) row.FindControl("HdfValue");
        if(ChkTest.Checked)
        {
            Console.WriteLine(HdfValues.Value);
        }
    }
