    public frmAdd MyOtherForm { get; set; }
    private void btnCancel_Click(object sender, EventArgs e)
    {
        MyOtherForm.pctImage.Image = pctImage.Image;
    }
