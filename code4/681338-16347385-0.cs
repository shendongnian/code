        TextBox txtAcessorio4 = (TextBox)gpbCategoria.Controls.Find("txtAcessorio4", false).FirstOrDefault();
    Label lblAcessorio4 = (Label)gpbCategoria.Controls.Find("lblAcessorio4", false).FirstOrDefault();
            
                        if (txtAcessorio4 != null && txtAcessorio4.Text == "" && lblAcessorio4.Name == "lblAcessorio4")
                        {
                            MessageBox.Show("Perfect");                           
                        }
