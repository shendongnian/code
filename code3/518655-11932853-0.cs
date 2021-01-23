    public DialogResult ShowMessage(string text)
    {
        DialogResult dialogResult = DialogResult.OK;
        if (!string.IsNullOrEmpty(text))
        {
            FrmDialog frmDialog = new FrmDialog(text);
            dialogResult = frmDialog.ShowDialog();
        }
        return dialogResult;
    }
