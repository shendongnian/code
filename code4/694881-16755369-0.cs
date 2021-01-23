    // Initialize
    myMenuStrip.ItemClicked += itemClickedEvent;
    
    // ...
    void itemClickedEvent(Object sender, ToolStripItemClickedEventArgs e)
    {
      int index = myObjectList.FindIndex(e => e.instanceOfUserControl == e.ClickedItem);
      // Now that we have the clicked item, display it how we would in an individual event handler.
      myObjectList[index].instanceOfUserControl.DoDisplay();
    }
