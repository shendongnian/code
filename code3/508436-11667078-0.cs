       DataColumnCollection dcCollection = datatable.Columns; // get cols
       if (dcCollection.Contains(dcName))
       {
           dcCollection.Remove(dcName); /// remove columns
         // but you have not updated you datatable columns.
            here should be something like this
           datatable.Columns = dcCollection; /// i don't know this will work or not check it
       }
     
