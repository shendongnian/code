    protected void loadTable()
        {
            HtmlTable tblDDF = new HtmlTable();
            //var objDDF = new ddf();
            //DataSet dsDdfDetail = new DataSet();
            //if (dsDdfDetail.Tables[0].Rows.Count > 0)
            //{
                //int RowsCount = dsDdfDetail.Tables[0].Rows.Count;
                for (int i = 0; i < 5; i++)
                {
                    HtmlTableRow tblNewRow = new HtmlTableRow();
                    HtmlTableCell tblDdfCell = new HtmlTableCell();
                    tblDdfCell.Controls.Add(addCheckbox(i.ToString()));
                    //The addCheckbox function returns the checkbox with its text
                    tblNewRow.Controls.Add(tblDdfCell);
                    tblDDF.Controls.Add(tblNewRow);
                }
                HtmlTableRow htFooterRow = new HtmlTableRow();
                HtmlTableCell htFooterCell = new HtmlTableCell();
                htFooterCell.Controls.Add(DelButton());
                //DelButton() is written in below
                htFooterCell.Attributes.Add("class", "pnlFooterRow");
                htFooterCell.ColSpan = 2;
                htFooterRow.Cells.Add(htFooterCell);
                tblDDF.Controls.Add(htFooterRow);
            //}
            pnlShowDDF.Controls.Add(tblDDF);
            pnlShowDDF.Visible = true;
        }
    protected Button DelButton()
        {
            var btnDelete = new Button();
            btnDelete.ID = "btnDelete";
            btnDelete.Text = "De-Allocate";
            btnDelete.Click += new EventHandler(btnDelete_Click);
            btnDelete.Attributes.Add("class", "button");
            //btnDelete.ViewStateMode = ViewStateMode.Enabled;
            return btnDelete;
        }
    protected CheckBox addCheckbox(string id)
        {
            CheckBox chk = new CheckBox();
            chk.ID = id;
            return chk;
        }
    void btnDelete_Click(object sender, EventArgs e)
        {
            //Need to access the checkbox id's here
            foreach (Control chk in pnlShowDDF.Controls)
            {
                if (chk is HtmlTable)
                {
                    HtmlTable tbl = (HtmlTable)chk;
                    foreach (HtmlTableRow row in tbl.Rows)
                    {
                        foreach (HtmlTableCell cell in row.Cells)
                        {
                            foreach (Control chk1 in cell.Controls)
                            {
                                if (chk1 is CheckBox)
                                {
                                    CheckBox chkbx = chk1 as CheckBox;
                                    if (chkbx.Checked)
                                    {
                                        //Here i need to access the id's which i can't right now
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
