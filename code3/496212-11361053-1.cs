    protected void EditButton_Click(object sender, EventArgs e)
    {
        Object someSource=null;
        FormViewDiagnostic.ChangeMode(FormViewMode.Edit);
        FormViewDiagnostic.DataSource = someSource;
        FormViewDiagnostic.DataBind();
    }
    
    protected void FormViewDiagnostic_DataBound(Object sender, EventArgs e)
    {
        var view = (FormView)sender;
        if (view.CurrentMode == FormViewMode.Edit)
        {
            var txt1 = (TextBox)view.FindControl("DIAG_COMPL_DATETextBox");
            var txt2 = (TextBox)view.FindControl("DIAG_REVIEW_COMPL_DATETextBox");
            var txt3 = (TextBox)view.FindControl("DIAG_LL_COMMENTSTextBox");
            var rbl = (RadioButtonList)view.FindControl("DIAG_LL_APPROVALRadioButtonList");
            txt3.Enabled = rbl.Enabled = txt1.Text.Length != 0 && txt2.Text.Length != 0;
        }
    }
