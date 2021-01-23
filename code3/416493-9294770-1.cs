        #region ModalPopUpS Privacy credits
    protected void btMpePrivacy_Click(object sender, EventArgs e)
    {
        pnlAjaxArea.Visible = true;
        AjaxControlToolkit.ModalPopupExtender modalPop = ((AjaxControlToolkit.ModalPopupExtender)(this.Master.FindControl("ContentPlaceHolder1").FindControl("MpePrivacy")));
        modalPop.Show();
    }
    protected void btMpeCredits_Click(object sender, EventArgs e)
    {
        pnlAjaxArea.Visible = true;
        AjaxControlToolkit.ModalPopupExtender modalPop = ((AjaxControlToolkit.ModalPopupExtender)(this.Master.FindControl("ContentPlaceHolder1").FindControl("MpeCredits")));
        modalPop.Show();
    }
    protected void btMpeClose(object sender, EventArgs e)
    {
        pnlAjaxArea.Visible = false;
    }
    #endregion
