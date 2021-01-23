        {
            lp = new ListPicker();            
            lp.BorderBrush = new SolidColorBrush(Colors.White);
            lp.BorderThickness = new Thickness(3);
            lp.Margin = new Thickness(12, 5, 0, 0);
            lp.Width = 400;
            int x = noofrows();
            for (int a = 1; a <= x; a++)
            {
                string str1 = returnID(a);
                lp.Items.Add(str1);                
            }
            lp.SelectionChanged += (s, e) =>
            {
                selectedItem = Convert.ToInt32(lp.SelectedItem);
                txtid.Text = selectedItem.ToString();
                txtName.Text = SelectName(selectedItem);
                txtAge.Text = SelectAge(selectedItem);
                txtContact.Text = SelectContact(selectedItem);
            };
            LayoutRoot.Children.Add(lp);    
            
        }
