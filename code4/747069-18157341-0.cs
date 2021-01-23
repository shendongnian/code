     String for96='',for97='',for98='';
     while (dr.Read())
         {
             int yil = Convert.ToInt32(dr["yil"].ToString());
             ListViewItem lvitem = new ListViewItem();
                   
             if (yil == 1996)
             {
                 for96 =(dr["OrderID"].ToString() + "--" + dr["Fiyat"].ToString() );
             }
             else if (yil == 1997)
             {
                 for97 = dr["OrderID"].ToString() + "--" + dr["Fiyat"].ToString();
             }
             else if (yil == 1998)
             {
                 for98=dr["OrderID"].ToString() + "--" + dr["Fiyat"].ToString();                
             }
             if (!String.IsNotNullOrEmpty(for96) && !String.IsNotNullOrEmpty(for97) && !String.IsNotNullOrEmpty(for98))
             {
                 ListViewItem itm = listView1.Items.Add(for96);
                 itm.SubItems.Add(for97);          
                 itm.SubItems.Add(for98);      
                 
                 for96='',for97='',for98='';
             }
                 
         }
