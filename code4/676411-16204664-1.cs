    private void btnClassification_Click(object sender, EventArgs e)
    {
        classification control = new classification();
        formMain main = (formMain)this.GetParentForm();
        main.panelMain.Controls.Clear();
        main.panelMain.Controls.Add(control);
    }
