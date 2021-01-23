    private void btnSaveFilter_Click(object sender, EventArgs e)
    {
        foreach (Control control in panelFiltri.Controls)
        {
            if (control is ComboBox)
            {
                string valueInComboBox = control.Text;
                // Do something with this value
            }
        }
    }
