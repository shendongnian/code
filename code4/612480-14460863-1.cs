    hyperLinkEdit.Buttons[0].Kind = ButtonPredefines.Glyph;
    hyperLinkEdit.Buttons[0].Caption = "Get SQL Query";
    hyperLinkEdit.ButtonClick += hyperLinkEdit_ButtonClick;
    hyperLinkColumn.ShowButtonMode = ShowButtonModeEnum.ShowAlways; // always display button in this column
    //...
    void hyperLinkEdit_ButtonClick(object sender, ButtonPressedEventArgs e) {
        MessageBox.Show("HyperLinkEdit's button clicked!");
    }
