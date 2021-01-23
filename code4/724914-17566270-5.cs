    void SetToolTip(Intellisense intellisenseitem)
     {
        toolTip.ToolTipTitle = title;
        var x = Width + 3;
        // get the rectangle of the selected item, the X, Y position of the rectangle will be relative to parent list box.
        var rect = listBox1.GetItemRectangle(listBox1.SelectedIndex); 
        var y = listBox1.Location.Y + rect.Y; // Add ListBox Y and the Selected Item Y to get the absolute Y.
        toolTip.Show(text, this, x, y, 3000);
     }
