    protected override void Render(HtmlTextWriter writer)
        {
            if (innerGridView.HeaderRow != null)
            {
                for (int i = 0; i < innerGridView.HeaderRow.Cells.Count; i++)
                {
                    innerGridView.HeaderRow.Cells[i].Attributes["onclick"] =
                        Page.ClientScript.GetPostBackClientHyperlink(innerGridView, "Sort$" + InnerGridViewDataTable.Columns[i].Caption, true);
                }
            }
            
            base.Render(writer);
        }
