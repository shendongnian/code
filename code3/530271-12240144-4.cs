    private void copy_clipboard_button_Click(object sender, EventArgs e)
    {
        //Starts the file writer
        using (StreamWriter sw = new StreamWriter("C:\\INET Portal Notes.txt"))
        {
            /* ... */
            //Statements to write checkboxes to file
            // This variable will store your whole line for check boxes.
            string checkBoxesLine = "**";
            // Enumerate all controls in panel.
            foreach (Control control in pnlCheckBoxes.Controls)
            {
                // Make sure the control is CheckBox, ignore others.
                if (control is CheckBox)
                {
                    // Cast it to CheckBox variable, to make it easier to work with.
                    CheckBox checkBox = (CheckBox)control;
                    // Make sure it is checked, and if it is, make sure that the Tag property
                    // has been set to string, so that we can get it's ID (WLAN, DSL, etc.).
                    if (checkBox.Checked && checkBox.Tag is string)
                    {
                        // Cast tag to string.
                        string checkBoxId = (string)checkBox.Tag;
                        // Append tag and comma to the end of the line.
                        checkBoxesLine += string.Format("{0}, ", checkBoxId);
                    }
                }
            }
            // That's it, we have the whole line, write it as a new line.
            sw.WriteLine(checkBoxesLine);
            //Continues textboxes to file
            /* ... */ 
        }
    }
