        if (grid != null)
        {
            GridItem[] footerItems = grid.MasterTableView.GetItems(GridItemType.Footer);
            if (footerItems.Length == 1)
            {
                GridTFoot foot = footerItems[0].Parent.Controls[0].Parent as GridTFoot;
                for (int i = 0; i < foot.Controls.Count; i++)
                {
                    GridFooterItem item = foot.Controls[i] as GridFooterItem;
                    if (item != null)
                    {
                        lastFooterPos = i;
                        break;
                    }
                }
                GridFooterItem existingFooter = foot.Controls[lastFooterPos] as GridFooterItem;
                GridFooterItem newFooterItem = new GridFooterItem(grid.MasterTableView, 0, 0);
               
                int k = 0;
                int l = 0;
                int n = 0;
                int p = 0;
                int a = 0;
                int b = 0;
                int c = 0;
                foreach (TableCell fc in existingFooter.Cells)
                {
                    //decimal cost = Convert.ToDecimal(existingFooter["Marks"].Text);
                    TableCell newFooterCell = new TableCell();
                   if (k==0)
                    {
                        newFooterCell.Text = "";
                        newFooterCell.Height = 12;
                        newFooterItem.Cells.Add(newFooterCell);
                        k = 1;
                    }
                     else
                    {
                        if (l==0)
                        {
                            newFooterCell.Text = "Total";
                            newFooterCell.Height = 12;
                            newFooterItem.Cells.Add(newFooterCell);
                            l = 1;
                        }
                        else
                        {
                            if (n == 0)
                            {
                                newFooterCell.Text = "sssTotal";
                                newFooterCell.Height = 12;
                                newFooterItem.Cells.Add(newFooterCell);
                                n = 1;
                            }
                            else
                            {
                                if (p == 0)
                                {
                                    newFooterCell.Text = "Another Total Footer:";
                                    newFooterCell.Height = 12;
                                    newFooterItem.Cells.Add(newFooterCell);
                                    p = 1;
                                }
                                else
                                {
                                    if (a == 0)
                                    {
                                        newFooterCell.Text =  Convert.ToString(existingFooter["Marks"].Text) ;
                                        newFooterCell.Height = 12;
                                        newFooterItem.Cells.Add(newFooterCell);
                                        a = 1;
                                    }
                                    else
                                    {
                                        if (b== 0)
                                        {
                                            newFooterCell.Text =  Convert.ToString(existingFooter["Fees"].Text);
                                            newFooterCell.Height = 12;
                                            newFooterItem.Cells.Add(newFooterCell);
                                            b = 1;
                                        }
                                        else
                                        {
                                            if (c == 0)
                                            {
                                                newFooterCell.Text = Convert.ToString(existingFooter["Noofstudents"].Text);
                                                newFooterCell.Height = 12;
                                                newFooterItem.Cells.Add(newFooterCell);
                                                c = 1;
                                            }
                                            else
                                            {
                                                newFooterCell.Text = "";
                                                newFooterCell.Height = 12;
                                                newFooterItem.Cells.Add(newFooterCell);
                                            }
                                        }
                                    }
                                }
                                
                            }
                        }
                    }     
                             
                            foot.Controls.AddAt(lastFooterPos + 1, newFooterItem);
                        
                    }
                }
            }
        }
