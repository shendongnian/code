    OpenFileDialog ofd = new OpenFileDialog();
    ofd.Filter = "XML Files (*.xml)|*.xml";
    ofd.FilterIndex = 0;
    ofd.DefaultExt = "xml";
    if (ofd.ShowDialog() == DialogResult.OK)
    {
    	if (!String.Equals(Path.GetExtension(ofd.FileName),
    	                   ".xml",
    	                   StringComparison.OrdinalIgnoreCase))
    	{
    	    // Invalid file type selected; display an error.
            MessageBox.Show("The type of the selected file is not supported by this application. You must select an XML file.",
                            "Invalid File Type",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                            
            // Optionally, force the user to select another file.
            // ...
    	}
    	else
    	{
    	    // The selected file is good; do something with it.
    	    // ...
    	}
    }
