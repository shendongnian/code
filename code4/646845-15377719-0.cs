        try
        {
        decimal Amnt;
        decimal.TryParse(txtAmnt.Text, out Amnt);
        int tnure=1;
        int.TryParse(txtTnre.Text, out tnure);
        txtDdctAmnt.Text = (Amnt /tnure).ToString("0.00");
        }
        catch(Exception ex)
        {
            // handle exception here
            Response.Write("Could not divide any number by 0");
        }
