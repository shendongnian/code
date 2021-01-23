    protected void EditButton_Click(object sender, EventArgs e)
    {
        Object someSource=null;
        FormViewDiagnostic.ChangeMode(FormViewMode.Edit);
        FormViewDiagnostic.DataSource = someSource;
        FormViewDiagnostic.DataBind();
    }
    protected void FormView_DataBound(Object sender, EventArgs e)
    {
        if (FormViewDiagnostic.CurrentMode == FormViewMode.Edit)
        {
            var txt = (TextBox)FormViewDiagnostic.FindControl("DIAG_COMPL_DATETextBox");
            // ...
        }
    }
