        private void txtR_TextChanged(object sender, EventArgs e)
    {
        if(txtR.Text.Trim().Length == 0 
        && txtE2.Text.Trim().Length == 0 
        && txtD2.Text.Trim().Length == 0 
        && txtP2.Text.Trim().Length == 0)
        {
            R = float.Parse(txtR.Text);
            E2 = float.Parse(txtE2.Text);
            E = R * E2;
            txtE.Text = E.ToString();
            R = float.Parse(txtR.Text);
            D2 = float.Parse(txtD2.Text);
            D = R * D2;
            txtD.Text = D.ToString();
            R = float.Parse(txtR.Text);
            P2 = float.Parse(txtP2.Text);
            P = R * P2;
            txtP.Text = P.ToString();
        
        }
        else{
            MessageBox.Show("One or more of the fields were empty!");
        {
     }
