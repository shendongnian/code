        private void txtBox_Enter(object sender, EventArgs e)
        {
            pnlList.Visible = true;
            pnlOther.Visible = false
        }
        private void txtBox_Leave(object sender, EventArgs e)
        {
            pnlList.Visible = false;
            pnlOther.Visible = true;
        }
