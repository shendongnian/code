    private void richTextBox1_MouseLeave(object sender, EventArgs e)
    {
        // If the left mouse button is down when leaving the rtb
        if (MouseButtons == MouseButtons.Left)
        {
            // Write everything to a temp file.
            System.IO.File.WriteAllText(@"z:\Temp\helloWorld.rtf", richTextBox1.SelectedRtf);
            string[] filenames = { @"z:\Temp\helloWorld.rtf" };
            DataObject obj = new DataObject();
            // Set the drag drop data with the FileDrop format
            obj.SetData(DataFormats.FileDrop, filenames);
            // Start the drag drop effect
            DoDragDrop(obj, DragDropEffects.All);
        }
    }
