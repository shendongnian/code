    public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            var btnComboBoxEdit = Template.FindName("ComboBoxEdit", this) as ComboBoxEdit;
            btnComboBoxEdit.PopupClosed +=new ClosePopupEventHandler(btnComboBoxEdit_PopupClosed);
        }
    private void btnComboBoxEdit_PopupClosed(object sender, ClosePopupEventArgs e)
        {
            EditValue = e.EditValue;
        }
