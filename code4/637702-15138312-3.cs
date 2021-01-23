    class Foo {
         private List<BootSale> someOtherList = // ...etc          
         public void DeleteSale()
         {
             foreach (BootSale b in lstBootSales.SelectedItems.OfType<BootSale>().ToArray())
             {
                someOtherList.Remove(b);
                lstBootSales.Items.Remove(b);
                //lstBootSales.Items.Remove(b.Id);
                //lstBootSales.Items.Remove(b.Date);
                DisplayAllBootSales();
             }
         }
     }
