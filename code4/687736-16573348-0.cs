    protected void ItemDetails_ItemCreated(object sender, EventArgs e)
            {
                if (dataItem2 != null) //compare enabled
                {
                    var headerRow = ((DetailsView)sender).HeaderRow;
                    var headerL = new Label();
                    headerL.Text = header2;
                    headerL.Style.Add("font-weight", "bold");
                    var headerCell = new TableCell();
                    headerCell.Controls.Add(headerL);
                    headerCell.Style.Add("text-align", "right");
                    headerRow.Cells.Add(headerCell);
                    if (string.IsNullOrEmpty(header1) && string.IsNullOrEmpty(header2)) ((DetailsView)sender).HeaderRow.Visible = false;
                }
                else
                {
                    ((DetailsView)sender).HeaderRow.Visible = false;
                }
                foreach (DetailsViewRow r in ItemDetails.Rows)
                {
                    if (r.RowType == DataControlRowType.DataRow)
                    {
                        // Assume the first cell is a header cell        
                        var dataCell = (DataControlFieldCell)r.Cells[0];
                        string dataFieldName = null;
                        if (dataCell.ContainingField is CustomBoundField) dataFieldName = ((CustomBoundField)dataCell.ContainingField).GetDataFieldName();
                        else if (dataCell.ContainingField is BoundField) dataFieldName = ((BoundField)dataCell.ContainingField).DataField;
                        if (dataItem2 != null) //compare enabled
                        {
                            if (!string.IsNullOrEmpty(dataFieldName)) //it's a field, copy boundField from hidden DetailsView
                            {
                                var ct = new TableCell();
                                var text = new StringWriter();
                                var html = new HtmlTextWriter(text);
                                dict[dataFieldName].RenderControl(html);
                                ct.Text = text.ToString().Replace("<td>", String.Empty).Replace("</td>", String.Empty);
                                r.Cells.Add(ct);
                            }
                        }
                    }
                } 
            }
