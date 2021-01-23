    Form active_form = Form.ActiveForm;
    if (active_form == null) return;
    Control control = Form.ActiveForm.ActiveControl;
    if (control == newFilesList)
    {
      Sync_lists(newFilesList);
    }
    else
    {
      Sync_lists(oldFilesList);
    }
