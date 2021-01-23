    protected void RadGrid1_ItemDataBound1(object sender, GridItemEventArgs e)
    {
        if (e.Item is GridDataItem)
        {
            GridDataItem dataItem = e.Item as GridDataItem;
            string payment = dataItem["PaymentAmount"].Text;
            decimal fieldValue = decimal.Parse(payment);
            total += fieldValue;
            dataItem["Balance"].Text = total.ToString();
        }
        
        if (e.Item is GridFooterItem)
        {
            GridFooterItem footerItem = e.Item as GridFooterItem;
            footerItem["PaymentAmount"].Text = "total: " + total.ToString();
        }
    }
