    Add following code after htmlwriter line
    `if (dtDetails.Rows.Count > 0)
                {
                    for (int i = 0; i < gvProduction.HeaderRow.Cells.Count; i++)
                    {
                        gvProduction.HeaderRow.Cells[i].Style.Add("background-color", "#507CD1");
                    }
                    int j = 1;
                    //This loop is used to apply stlye to cells based on particular row
                    foreach (GridViewRow gvrow in gvProduction.Rows)
                    {
                        gvrow.BackColor = Color.White;
                        if (j <= gvProduction.Rows.Count)
                        {
                            if (j % 2 != 0)
                            {
                                for (int k = 0; k < gvrow.Cells.Count; k++)
                                {
                                    gvrow.Cells[k].Style.Add("background-color", "#EFF3FB");
                                }
                            }
                        }
                        j++;
                    }
                    gvProduction.RenderControl(hw);
                    Response.Write(sw.ToString());
                    Response.End();
                }`
