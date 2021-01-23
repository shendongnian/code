    method MainForm.MainForm_Load(sender: System.Object; e: System.EventArgs);
    var
      KC: Dictionary<String, Int32>.KeyCollection;
    begin
      aItems := new Dictionary<String, Int32>;
      aItems.Add('15 min', 15);
      aItems.Add('30 min', 30);
      aItems.Add('1 hr', 60);
      aItems.Add('1 hr 30 min', 90);
      aItems.Add('2 hr', 120);
      aItems.Add('2 hr 30 min', 150);
      KC := aItems.Keys;
      for s in KC do
        comboBox2.Items.Add(s);
      comboBox2.DropDownStyle := ComboBoxStyle.DropDownList;
    end;
    method MainForm.comboBox2_SelectedIndexChanged(sender: System.Object; e: System.EventArgs);
    begin
      // Safe since style is DropDownList. 
      label1.Text := aItems[comboBox2.SelectedItem.ToString].ToString(); 
    end;
