    private void AddEntry(string attribute, string value){
       Label lbl = new Label {Text=attribute, Dock=DockStyle.Top};
       lbl.Parent = splitContainer1.Panel1;//This is the same to splitContainer1.Panel1.Controls.Add(lbl);
       lbl.BringToFront();
       TextBox txt = new TextBox {Text=value, Dock=DockStyle.Top};
       txt.Parent = splitContainer1.Panel2;
       txt.BringToFront();
       lbl.Height = txt.Height;
    }
    //I guess you want to add new entry to your splitContainer in this foreach
    foreach (EA.Element theElement in myPackage.Elements)
    {
      foreach (EA.Attribute theAttribute in theElement.Attributes)
      {
         Attributes = theAttribute.Name.ToString();
         Values = theAttribute.Default.ToString();
         //call the method above
         AddEntry(Attributes, Values);
         tag = tag + Attributes + Values + Environment.NewLine;
      }
    }
