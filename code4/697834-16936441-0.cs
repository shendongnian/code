     private void Remove_all_PushPins_click(object sender, EventArgs e)
         {
              MessageBoxResult m =  MessageBox.Show("All PushPins will be deleted", "Alert", MessageBoxButton.OKCancel);
              if (m == MessageBoxResult.OK)
              {
                      pushpin_layer.Children.Clear();
              }
     
          }
