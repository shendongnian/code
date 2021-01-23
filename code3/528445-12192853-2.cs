        public List<T> Load<T>(string fileName)
        {
            var list = new List<T>();
            // Check if we had previously Save information of our friends
            // previously
            if (File.Exists(fileName))
            {
                try
                {
                    // Create a FileStream will gain read access to the
                    // data file.
                    FileStream readerFileStream = new FileStream(fileName,
                        FileMode.Open, FileAccess.Read);
                    // Reconstruct information of our friends from file.
                    list = (List<T>)
                        m_formatter.Deserialize(readerFileStream);
                    // Close the readerFileStream when we are done
                    readerFileStream.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            return list;
        }
