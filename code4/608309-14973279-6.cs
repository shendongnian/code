    button.Hold += new EventHandler<System.Windows.Input.GestureEventArgs>(SomeHoldEvent);
 
     private void SomeHoldEvent(object sender, EventArgs e)
            {
                contextMenu = new ScrollableContextMenu(this, definedList);
                contextMenu.ListBoxTap +=new ScrollableContextMenu.TapHandler(contextMenu_ListBoxTap);
                contextMenu.Show();
            }
