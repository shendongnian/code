    int i = 0;
    foreach (myObject object in myList)
    {
         if (object.Status == Status.Available)
         {
             myDataGridView.Rows.Add(object.Name, object.Status.ToString(), i);
         }
         i++;
    }
    //Hide the third column
    myDataGridView.Columns[2].Visible = false;
