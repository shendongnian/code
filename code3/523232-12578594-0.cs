        int j = 0;
            foreach (Control current in tableId.Controls[0].Controls)
            {
                if (current.ToString() == "System.Web.UI.WebControls.TableHeaderCell")
                {
                    j++;
                }
            }
