    public frmAdd MyFirstForm { get; set; }
    private void btnCancel_Click(object sender, EventArgs e)
    {
        MyFirstForm.pctImage.Image = pctImage.Image;
    }
