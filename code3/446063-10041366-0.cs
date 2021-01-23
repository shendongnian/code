    private void grid_Item_Click(object sender, RoutedEventArgs e) 
    { 
    Button btn = sender as Button; 
    int x=(int)btn.GetValue(Grid.RowProperty); 
    int y=(int)btn.GetValue(Grid.ColumnProperty);  
      MessageBox.Show("row"+x.ToString()+"column"+y.ToString());
     }
