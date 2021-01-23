    Regex staffNumVal = new Regex(@"^[0-9]+$");
    if (staffNumVal.IsMatch(txtStaffHPhone.Text)||(staffNumVal.IsMatch(txtStaffHourRate.Text)))
    {
      //Valid
    }
    else
    {
      MessageBox.Show("Please enter a numeric value");
    }
