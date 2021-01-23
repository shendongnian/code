    private void tabControl1_Selected(object sender, TabControlEventArgs e) {
      if (e.TabPage == tpExpenseReport) {
        txtTripNo.Visible = true;
        txtTripNo2.Visible = false;
      } else if (e.TabPage == tpExpenseReview) {
        txtTripNo.Visible = false;
        txtTripNo2.Visible = true;
      }
    }
