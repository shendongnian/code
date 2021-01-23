    private void cbalpha_SelectedIndexChanged(object sender, EventArgs e)
        {
          
            bool isEnabled = string.Compare(StringtDataChoiceorSelect.SelectedItem.ToString(),"(Initiate)",StringComparison.OrdinalIgnoreCase) == 0;
            foreach (Control cb in this.Controls)
                cb.Enabled = !isEnabled ;
    
        }
