    private void listBoxControl1_DrawItem(object sender, DevExpress.XtraEditors.ListBoxDrawItemEventArgs e) {
        if(e.State == DrawItemState.Focus || e.State== DrawItemState.Selected) {
            e.Appearance.BackColor = Color.Red;
        }
    }
