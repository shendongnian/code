    private void listBox1_DrawItem(object sender, DrawItemEventArgs e)
    {
        MyListBoxItem item = listBox1.Items[e.Index] as MyListBoxItem; // Get the current item and cast it to MyListBoxItem
        if (item != null)
        {
            float width = e.Graphics.MeasureString(item.Message, listBox1.Font).Width + 3;
            e.Graphics.DrawString( // Draw the appropriate text in the ListBox
                       item.Message, // The message linked to the item
                       listBox1.Font, // Take the font from the listbox
                       new SolidBrush(item.ItemColor), // Set the color 
                       listBox1.Width - width, // X pixel coordinate
                       e.Index * listBox1.ItemHeight); // Y pixel coordinate.  Multiply the index by the ItemHeight defined in the listbox.                
        }
        else
        {
            // The item isn't a MyListBoxItem, do something about it
        }
    }
