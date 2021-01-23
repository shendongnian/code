    listView1.Items.Clear();
            listView1.View = View.Details;
            
            List<Ingredient> list = controller.FindAllIngredients();
            foreach (Ingredient o in list)
            {
                ListViewItem lvi = new ListViewItem();
                
                lvi.Text = o.iName;
                lvi.SubItems.Add(o.iUnit);
                lvi.SubItems.Add(Convert.ToString(o.iCalories));
                listView1.Items.Add(lvi);
                
            }   
