    int realopid = 0;
    try
    {
       realopid = Convert.ToInt16(operatorid);
    }
    catch (OverflowException)
    {
        //Create Message Box
        MessageBox.Show("Please Scan Valid Operator ID", "Operator ID");
        operatorid = Microsoft.VisualBasic.Interaction.InputBox("Scan Operator ID", "Operator ID");
     }
    string res = lookupName(realopid);
