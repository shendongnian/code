        class ClosableTab : TabItem
         {
            // Constructor
          public ClosableTab()
          {
             // Create an instance of the usercontrol
             closableTabHeader = new CloseableHeader();
             // Assign the usercontrol to the tab header
             this.Header = closableTabHeader;
           }
        }
