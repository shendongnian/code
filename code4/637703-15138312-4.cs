    class Foo {
        BootSaleList bootsalelist;
        public void DeleteSale()
        {
            foreach (BootSale b in lstBootSales.SelectedItems.OfType<BootSale>().ToArray())
            {
                //temp.Remove(b); -- no more of this guy
                bootsalelist.ReturnList().Remove(b);
                lstBootSales.Items.Remove(b);
                
                // and no more of these guys:
                //lstBootSales.Items.Remove(b.Id); 
                //lstBootSales.Items.Remove(b.Date);
                //DisplayAllBootSales();
            }
        }
     }
