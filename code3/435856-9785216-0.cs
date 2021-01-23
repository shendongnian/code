     protected void ASPxGridView1_HtmlDataCellPrepared(object sender, ASPxGridViewTableDataCellEventArgs e) {
            if(e.DataColumn.FieldName == "title") {
                ASPxTextBox textBox = ASPxGridView1.FindRowCellTemplateControl(e.VisibleIndex, e.DataColumn, "ASPxTextBox1") as ASPxTextBox;
                textBox.Text = Convert.ToString(e.CellValue);
            }
        }
