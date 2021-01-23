    foreach (DataGridViewRow item in grdGLSearch.Rows)
                {
                    if (item.Visible)
                    {
                        item.Selected = true;
                        break;
                    }
                }
