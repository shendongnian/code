    public Form1()
     {
      ComboBox box = new ComboBox();
      Controls.Add(box);
      // EXPECT: DataMember not found exception
      // RESULT: Exception not thrown!
      box.DataBindings.Add("Text", new Entity(), "asdhjgfjhrt");
     }
