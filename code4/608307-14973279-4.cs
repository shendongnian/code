    public class ScrollableContextMenu
        {
            private Popup p;
            public delegate void TapHandler(object sender, System.Windows.Input.GestureEventArgs e);
            public event TapHandler ListBoxTap;
    
            private ListBox listBox;
    
            public ListBox ListBox
            {
                get { return listBox; }
                set { listBox = value; }
            }
            /// <summary>
            /// Create new Context Menu. The items of Context Menu will be taken from given list
            /// </summary>
            /// <param name="page"></param>
            /// <param name="items"></param>
            public ScrollableContextMenu(PhoneApplicationPage page, List<string> items)
            {
                p = new Popup();
    
               // Generate popup properties, i.e. height, width, e.t.c.
    
                Canvas canvas = new Canvas();
    
                // Generate canvas main properties
                p.Child = canvas;
    
                Border border = new Border();
               
                // Now create border and its main properties
                canvas.Children.Add(border);
    
                // StackPanel.
                StackPanel panel = new StackPanel();
                panel.Orientation = System.Windows.Controls.Orientation.Vertical;
    
                // Create listBox, that we will be scrolling
                listBox = new ListBox();
                // Create listbox main properties
                // Fill the listbox with items. 
                foreach (string item in items)
                    listBox.Items.Add(new ScrollableContextMenuItem(item));
                listBox.Tap += listBoxTap;
                panel.Children.Add(listBox);
                border.Child = panel;
            }
    
            public void Show()
            {
                // Open the popup.
                p.IsOpen = true;
                p.UpdateLayout();
            }
    
            public void Close()
            {
                // Close it
                p.IsOpen = false;
                p.UpdateLayout();
            }
    
            private void listBoxTap(object sender,  System.Windows.Input.GestureEventArgs e)
            {
                // Invoke hanlder if it exists
                if (ListBoxTap != null)
                    ListBoxTap(sender, e);
            }
