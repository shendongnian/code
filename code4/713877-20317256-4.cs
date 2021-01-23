    class OPC_client{
      // Tracked bool array
      public BoolArray_Tracked ItemActive{get; set;}
      // Constructor
      public OPC_client(bool[] boolItemActive){
        ItemActive = new BoolArray_Tracked(boolItemActive);
        ItemActive.RaiseIndexEvent += Handle_ItemActive_IndexChange;
      }
      // State what should happen when an item changes
      private void Handle_ItemActive_IndexChange(object sender, IndexEventArgs e){
        //if (_theGroup != null) {//Your code in the question
          int itemIndex = e.Index; 
          //int itemHandle = itemHandles[itemIndex]; //Your code
          //_theGroup.SetActiveState(itemHandle, value, out err); // Yours
        //} //Your code
      
        Console.WriteLine("The array `ItemActive' was changed"
          + " at entry " + itemIndex.ToString() 
          + " to value " + e.Value.ToString());
      }
    }
