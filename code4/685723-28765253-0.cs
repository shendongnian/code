    string perfilText = "";
    ...   
    private void cbPerfis_KeyUp(object sender, KeyEventArgs e)
    {
                if (e.KeyData != Keys.Enter)
                {                
                    perfilText = cbPerfis.Text;
                }
                else
                {
                    cbPerfis.Text = perfilText;
                    cbOrdens.Focus();
                }
    }
