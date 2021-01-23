     // Assuming CustomerList is a List<Customers> defined and initialized somewhere
     int prevCount = -1;
     int lastSelectedId = 0;
     while (prevCount < CustomerList.Count) {
      prevCount = CustomerList.Count;
      CustomerList.Append(ReturnListOfCustomers(lastSelectedId));
      // Need to check for null return condition
      if (CustomerList.Count > 0) {
        lastSelectedId = CustomerList.Last().rowId;
      }
    }
