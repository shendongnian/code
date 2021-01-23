    private void txtnapsaserach_TextChanged(object sender, EventArgs e)
    {
        float value = 0;
        if(!string.IsNullOrEmpty(txtnapsaserach.Text) && float.TryParse(txtnapsaserach.Text, out value) && value > 0)
        {
            // your logic here
        {
    }
