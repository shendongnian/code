    private void cmbValue_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ComboBox cmb = sender as ComboBox;
            cmb.Items.Clear();
    
            //Iterates through all virtual tables
            foreach (TableContainer table in parentTable.ParentVisualQueryBuilder.ListOpenUnjoinedTables)
            {
                ComboBoxItem item = new ComboBoxItem();
                item.MouseMove += item_MouseMove;
    
                if (table.IsVirtual == false)
                {
                    item.Content = "[" + table.TableDescription + "]";
                }
                else
                {
                    item.Content = "[" + table.View.Name + "]";
                }
    
                item.Tag = table;
                cmb.Items.Add(item);
            }
        }
