        //...
        gridView.ShownEditor += gridView_ShownEditor;
        gridView.HiddenEditor += gridView_HiddenEditor;
    }
    void gridView_ShownEditor(object sender, EventArgs e) {
        gridView.ActiveEditor.EditValueChanged += ActiveEditor_EditValueChanged;
    }
    void gridView_HiddenEditor(object sender, EventArgs e) {
        gridView.ActiveEditor.EditValueChanged -= ActiveEditor_EditValueChanged;
    }
    void ActiveEditor_EditValueChanged(object sender, EventArgs e) {
        gridView.PostEditor();
    }
