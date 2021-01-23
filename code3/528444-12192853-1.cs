    /// <summary>
    /// Saves the object information
    /// </summary>
    public void Save<T>(string fileName, List<T> list)
    {
        // Gain code access to the file that we are going
        // to write to
        try
        {
            // Create a FileStream that will write data to file.
            FileStream writerFileStream =
                new FileStream(fileName, FileMode.Create, FileAccess.Write);
            m_formatter.Serialize(writerFileStream, list);
            // Close the writerFileStream when we are done.
            writerFileStream.Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        } 
    }
