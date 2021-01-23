    private void SubmenuItem_Click(object sender, EventArgs e)
    {
        var clickedMenuItem = sender as MenuItem; 
        EnumType item = (EnumType)clickedMenuItem.Tag;
    
        switch(item) {
            case TigeItem:
               break;
            case LionItem:
              break;
             ...
        }
    }
