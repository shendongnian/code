    e.Row.Cells[iDelete].Controls.Add
                (new ImageButton
                {
                    ImageUrl = "Images/database_delete.png",
                    CommandArgument = e.Row.RowIndex.ToString(),
                    CommandName = "Delete",
                    ID = "imgEmpDelete" + e.Row.Cells[iID].Text,
                    **OnClientClick = "javascript:return rowAction(this.name)",**
                    ClientIDMode = System.Web.UI.ClientIDMode.Static
                });
