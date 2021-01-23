        CheckBox box = new CheckBox();
        box.CheckedChanged += new EventHandler(box_CheckedChanged);
        
        // Event Handler
        void box_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is CheckBox)
            {
                CheckBox cb = (CheckBox)sender;
                bool checkState = cb.Checked;
            }
        }
