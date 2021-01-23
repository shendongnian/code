      private void pivoteSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
             
            Pivot pivot = (Pivot)sender;
          
            if (lastselectedIndex == 2 && pivot.SelectedIndex == 0)
            {
                pivot.SelectedIndex= 2;
                return;
            }
            else if (lastselectedIndex == 0 && pivot.SelectedIndex == 2)
              {
                pivot.SelectedIndex= 0;
                return;
            }
           
            
            lastselectedIndex = pivote.SelectedIndex;
        }
