     //Hold previous value
     private string _previousItem;
     //IMPORTANT:
     //After binding items to combo box you will need to assign, 
     //default selected item to '_previousItem', 
     //which will make sure SelectedIndexChanged works all the time
     
     // Usage of Custom Event
     private void comboBox1_SelectedIndexChanged(object sender, 
		System.EventArgs e)
     {
          string selectedItem = (string)comboBox1.SelectedItem;
          if(string.Equals(_previousItem, )
          switch(_previousItem)
          {
              case  "z":
              {
                  SpecialIndexMonitor spIndMonitor = new SpecialIndexMonitor();
                  spIndMonitor.SpecialIndexSelected += 
                       new EventHandler<SpecialIndexEventArgs>(SpecialIndexSelected);
                  break;
              } 
              case "a":
              case "b":
                  break;   
          }
          _previousItem = selectedItem; //Re-Assign the current item
     }
     void SpecialIndexSelected(object sender, SpecialIndexEventArgs args)
     {
         // Your code goes here to handle the special index
     }
