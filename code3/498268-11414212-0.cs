     protected void Page_Load(object sender, EventArgs e) {
            LoadDetail();
        }
        private void LoadDetail() {
            HtmlTable tbl = new HtmlTable();
            HtmlTableRow row = new HtmlTableRow();
            HtmlTableCell cell = new HtmlTableCell();
            Button bUpdate = new Button();
            bUpdate.Text = "Update";
            bUpdate.Click += this.Update_Click;
            bUpdate.ID = "btnID";
            cell.Controls.Add(bUpdate);
            row.Cells.Add(cell);
            tbl.Rows.Add(row);
            div_Detail.Controls.Add(tbl);
        }
        private void Update_Click(object sender, EventArgs e) {
            //Do something 
        } 
