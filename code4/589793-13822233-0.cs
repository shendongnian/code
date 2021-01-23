    DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit buttonEdit = 
        new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
    buttonEdit.Buttons[0].Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph;
    buttonEdit.Buttons[0].Caption = "X";
    buttonEdit.TextEditStyle =             
        DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
    e.RepositoryItem = buttonEdit;
