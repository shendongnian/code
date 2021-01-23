            if (e.Row.RowType == DataControlRowType.Footer)
            {
                var but = new LinkButton();
                but.Text = "Save";
                e.Row.Cells[0].Controls.Add(but);
            }      
