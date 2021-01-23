     // Create Complete List
     ObservableCollection<TankstellenItem> completeList = new ObservableCollection<TankstellenItem>();
     // Loop through each TankstellenItem in listItem
     foreach(TankstellenItem tItem in listItem) {
          // Create an ObservableCollection to store FuelItem objects
          ObservableCollection<FuelItem> fuelList = new ObservableCollection<FuelItem>();
          // Loop through each FuelItem in the current TankstellenItem
          foreach(FuelItem fItem in tItem) {
               // Add the FuelItem from current TankstellenItem to the ObservableCollection
               Debug.WriteLine("HERE AGAIN: " + fItem.Price);
               completeList.Add(new TankstellenItem() {
                    // Add the FuelItem
                    Fuels = new ObservableCollection<FuelItem>() { 
                         fItem,
                    };
               }
          }
     }
