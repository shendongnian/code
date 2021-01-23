    void txtFonecom_KeyPress(object sender, KeyPressEventArgs e)
            {
                if (e.KeyChar != (char)Keys.Back)   
                {
                    if (txtFonecom.TextLength == 2)
                    {
                        txtFonecom.Text = txtFonecom.Text + " ";
                        txtFonecom.SelectionStart = 3;
                    }
    
                    if (txtFonecom.TextLength >= 7 && txtFonecom.TextLength < 12)
                    {
                        if (txtFonecom.Text.Substring(2, 1) == " ") //check if " " exists
                        { }
                        else //if doesn't exist, then add " " at index 2 (character no. 3)
                        {
                            txtFonecom.Text = txtFonecom.Text.Replace(" ", String.Empty);
                            txtFonecom.Text = txtFonecom.Text.Insert(2, " ");
                        }
    
                        txtFonecom.Text = txtFonecom.Text.Replace("-", String.Empty);   //now add "-" at index 7 (character no. 8)
                        txtFonecom.Text = txtFonecom.Text.Insert(7, "-");
                        txtFonecom.SelectionStart = txtFonecom.Text.Length;
                    }
    
                    if (txtFonecom.TextLength >= 12)
                    {
                        if (txtFonecom.Text.Substring(2, 1) == " ") //check if " " exists
                        { }
                        else    //if doesn't exist, then add " " at index 2 (character no. 3)
                        {
                            txtFonecom.Text = txtFonecom.Text.Replace(" ", String.Empty);
                            txtFonecom.Text = txtFonecom.Text.Insert(2, " ");
                        }
    
                        txtFonecom.Text = txtFonecom.Text.Replace("-", String.Empty);   //now add "-" at index 8 (character no. 9)
                        txtFonecom.Text = txtFonecom.Text.Insert(8, "-");
    
                        txtFonecom.SelectionStart = txtFonecom.Text.Length;
                    }
                }
            }
