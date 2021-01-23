        private void treeView1_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            int level = FindTreeLevel((TreeViewItem)treeView1.SelectedItem);
            if (level == 0)
            {
                textBox1.Text = "Item1";
            }
            else if (level == 1)
            {
                textBox1.Text = "Item1";
                textBox2.Text = "SubItem1";
            }
            //etc.
        }
        private int FindTreeLevel(TreeViewItem control)
        {
            var level = 0;
            if (control != null)
            {
                var parent = VisualTreeHelper.GetParent(control);
                while (!(parent is TreeView) && (parent != null))
                {
                    if (parent is TreeViewItem)
                        level++;
                    parent = VisualTreeHelper.GetParent(parent);
                }
            }
            return level;
        }
