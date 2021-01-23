        // Try to convert the R value just one time, everything fails if this fails
        if(!Single.TryParse(txtR.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out R))
            return; 
        if(Single.TryParse(txtE2.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out E2)) 
        {
            E = R * E2; 
            txtE.Text = E.ToString(); 
        }
 
        if(Single.TryParse(txtD2.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out D2))
        {
            D = R * D2; 
            txtD.Text = D.ToString(); 
        }
        if(Single.TryParse(txtP2.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out P2))
        {
            P = R * P2; 
            txtP.Text = P.ToString(); 
        }
 
