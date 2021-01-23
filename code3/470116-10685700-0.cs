    // create a writer and open the file
    using (TextWriter tw = new StreamWriter(
                                     txtFileName.Text, 
                                     false, 
                                     System.Text.Encoding.UTF8))
    {
        // write the content
        tw.Write(txtContent.Text);
        // close the stream
        tw.Close();
    }
