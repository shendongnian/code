     public bool TabIsSelected
     {
         get { return tabIsSelected; }
         set 
         {
              if (value && dataDisplay != null)
              {
                  dataDisplay.Children.Clear();
                  dataDisplay.Children.Add(tabControls[tabIndex]);
              }
              tabIsSelected = value;
         }
