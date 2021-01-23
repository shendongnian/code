    public void DeleteSale()
    {
        foreach (BootSale b in lstBootSales.SelectedItems.OfType<ListViewItem>().ToArray())
        {
            lstBootSales.Items.Remove(b.Id);
            lstBootSales.Items.Remove(b.Date);
            DisplayAllBootSales();
        }
    }
