    string a = "0123456789"; 
    string b = "";
    Regex reg = new Regex(@"^(|\d{10})$");
 
    if ( Regex.IsMatch( a, reg ) && Regex.IsMatch( b, reg )
        MessageBox.Show("Matched");
