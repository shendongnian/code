    foreach (DataControlField col in gridReviews.Columns)
            {
                if (col.HeaderText == "Name")
                {
                    col.Visible = false;
                }
            }
