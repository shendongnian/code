    public void DeleteSale()
    {
        List<T> temp = lstBootSales;
        foreach (BootSale b in lstBootSales.SelectedItems)
        {
            temp.Items.Remove(b.Id);
            temp.Items.Remove(b.Date);
            DisplayAllBootSales();
        }
        lstBootSales = temp;
    }
