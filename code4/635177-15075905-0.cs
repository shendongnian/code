    private void CreateMyListView()
     {
      // Create a new ListView control.
      ListView listView1 = new ListView();
      listView1.Bounds = new Rectangle(new Point(10,10), new Size(300,200));
      // Set the view to show details.
      listView1.View = View.Details;
      // Allow the user to edit item text.
      listView1.LabelEdit = true;
      // Allow the user to rearrange columns.
      listView1.AllowColumnReorder = true;
      // Display check boxes.
      listView1.CheckBoxes = true;
      // Select the item and subitems when selection is made.
      listView1.FullRowSelect = true;
      // Display grid lines.
      listView1.GridLines = true;
      // Sort the items in the list in ascending order.
      listView1.Sorting = SortOrder.Ascending;
      
      //Creat columns:
      ColumnHeader column1 = new ColumnHeader();
      column1.Text = "Customer ID";
      column1.Width = 159;
      column1.TextAlign = HorizontalAlignment.Left;
      ColumnHeader column2 = new ColumnHeader();
      column2.Text = "Customer name";
      column2.Width = 202;
      column2.TextAlign = HorizontalAlignment.Left;
      //Add columns to the ListView:
      listView1.Columns.Add(column1);
      listView1.Columns.Add(column2); 
      // Add the ListView to the control collection.
      this.Controls.Add(listView1);
     }
