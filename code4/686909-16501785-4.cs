    ListBox lbx = new ListBox();
    lbx.Size = new System.Drawing.Size(X,Y); //Set to desired Size.
    lbx.Location = new System.Drawing.Point(X,Y); //Set to desired Location.
    this.Controls.Add(listBox1); //Add to the window control list.
    lbx.DoubleClick += OpenFileandBeginEditingDelegate;
    lbx.BeginUpdate();
    for(int i = 0; i < numfiles; i++)
      lbx.Items.Add(Files[i]);
    lbx.EndUpdate();
