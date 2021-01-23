    foreach (GridViewRow Row in this.searchResults.SearchResultGrid.Rows)
                        {
                            if (Row.RowType == DataControlRowType.DataRow)
                            {
                                Row.Cells[0].Visible = false;
                            }
                        }
                        GridViewRow HeaderRow = this.searchResults.SearchResultGrid.HeaderRow;
                        HeaderRow.Cells[0].Visible = false;
