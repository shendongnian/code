    namespace WpfApplication1
    {
        class exGrid : Grid
        {
            public exGrid(string a, string b, string g)
            {
                // this.SetValue(exGrid.IsSharedSizeScopeProperty, true);
    
                for (int i = 1; i <= 2; i++)
                {
                    this.ColumnDefinitions.Add(new ColumnDefinition() { Width = GridLength.Auto, SharedSizeGroup = g });
                }
    
                this.SetValue(exGrid.ShowGridLinesProperty, true);
    
                TextBlock tx1 = new TextBlock();
                tx1.Text = a;
    
                TextBlock tx2 = new TextBlock();
                tx2.Text = b;
    
                tx1.SetValue(exGrid.ColumnProperty, 0);
                tx2.SetValue(exGrid.ColumnProperty, 1);
    
                this.Children.Add(tx1);
                this.Children.Add(tx2);
            }
        }
    }
