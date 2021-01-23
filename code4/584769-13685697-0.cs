    string itemClass = Globals.ThisAddIn.Application.ActiveInspector().CurrentItem.MessageClass;
    if (itemClass == "IPM.Appointment")
      // you have a calendar item
    else if (itemClass == "IPM.Task")
      // you have a task item
    else if (itemClass == "IPM.Note")
      // you have a message item
