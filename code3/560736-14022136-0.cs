        public class ItemBinding
           {
            List<Item> itemList = new List<Item>();
            Item it = null;
            DataRow dr = null;
            public void mapping()
              {
                      for (int i = 0; i <= 4; i++)
                         {
                          it = new Item();
                          it.qty = i;
                          it.name = "name" + i;
                          it.itemprice.Vendorname="vendor" + i;
                          it.itemprice.price = 20 * i;
                          itemList.Add(it);
                         }
              }
             public void binding()
             {
                  DataTable dt = new DataTable();
                       dt.Columns.Add(new DataColumn("item", typeof(string)));
                       dt.Columns.Add(new DataColumn("quantity", typeof(int)));
                       dt.Columns.Add(new DataColumn("vendor", typeof(string)));
          
                  //item list contains the detail of the class
                        foreach (Item c in itemList)
                             {
                                dr = dt.NewRow();
                                dr[0] = c.qty;
                                dr[1] = c.name;
                                dr[2] = c.itemprice.Vendorname;;
                                dt.Rows.Add(dr);
                              }
                      dataGridView1.AutoGenerateColumns = true;
                      dataGridView1.DataSource = dt;
                       }
              }
        public class Item
             {
                public int qty{ get; set; }
                public string name { get; set; }
                public ItemPrice itemprice { get; set; }
                public Item()
                     {
                       this.itemprice = new ItemPrice();
                      }
             }
              public class ItemPrice
                {
                 public string Vendorname { get; set; }      
                 public int price { get; set; }
                }
