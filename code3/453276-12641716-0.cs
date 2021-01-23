    Public void RgDueBalance_CustomAggregate(object sender, GridCustomAggregateEventArgs e)
            {
                e.Result = 0;
            }
            protected void CheckBox1_Changed(object sender, EventArgs e)
            {
                GridFooterItem footerItem = rgDueBalance.MasterTableView.GetItems(GridItemType.Footer)[0] as GridFooterItem;
                double pageSum = double.Parse(footerItem["MontMI"].Text.Replace("Total:", ""));
                CheckBox checkBox = sender as CheckBox;
                GridDataItem dataItem = checkBox.NamingContainer as GridDataItem;
                double value = double.Parse(dataItem["MontMI"].Text);
    
                if (checkBox.Checked)
                {
                    pageSum += value;
                }
                else
                {
                    pageSum -= value;
                }
                footerItem["MontMI"].Text = "Total: " + pageSum;
            }
           
    
    what this does is when you check one check box it sums the value, or the opposite for the unchecking.
    hope it helps you!
