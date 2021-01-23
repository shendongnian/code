        //init the listbox
        var listBox1 = new ListBox();
        listBox1.Location = new System.Drawing.Point(122, 61);
        listBox1.Size = new System.Drawing.Size(205, 147);
        listBox1.SelectionMode = SelectionMode.MultiExtended;
        Controls.Add(listBox1); //<-- point of interest
        
        //then set the DataSource
        listBox1.DataSource = lst;
        listBox1.DisplayMember = "Name";
        listBox1.ValueMember = "Age";
        //then set the selected values
        listBox1.SetSelected(0, true);
        listBox1.SetSelected(1, true);
