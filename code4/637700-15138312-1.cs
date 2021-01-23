    public void DeleteSale()
    {
        foreach (BootSale b in lstBootSales.SelectedItems.ToArray())
        {
            lstBootSales.Items.Remove(b.Id);
            lstBootSales.Items.Remove(b.Date);
            DisplayAllBootSales();
        }
    }
