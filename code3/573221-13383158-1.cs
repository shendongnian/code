    List<TextBox> boxes = new List<TextBox>();
    if (string.IsNullOrWhiteSpace(txtFname.Text))
    {
        //highlightTextBox= txtFname;
        boxes.Add(txtFname);
    }
    if (string.IsNullOrWhiteSpace(txtLname.Text))
    {
        //highlightTextBox = txtLname;
        boxes.Add(txtLname);
    }
    if (string.IsNullOrWhiteSpace(txtAddOne.Text))
    {
        //highlightTextBox = txtAddOne;
        boxes.Add(txtAddOne);
    }
    if (string.IsNullOrWhiteSpace(txtTown.Text))
    {
        //highlightTextBox = txtTown;
        boxes.Add(txtTown);
    }
    if (string.IsNullOrWhiteSpace(txtPostCode.Text))
    {
        //highlightTextBox = txtPostCode;
        boxes.Add(txtPostCode);
    }
    foreach (var item in boxes)
    {
        if (string.IsNullOrWhiteSpace(item.Text))
        {
            item.BackColor = Color.Azure;
        }
    }
    lblTopError.Text = "Please fill in the missing billing information highlighted below";
    pnlTopError.Visible = true;
