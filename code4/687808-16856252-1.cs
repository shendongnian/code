    public void Disposed()
        {
            if (m_streams != null)
            {
                foreach (Stream stream in m_streams)
                    stream.Close();
                m_streans = null;
            }
            
            //Delete every file created by the stream
            foreach (string file in _emfFiles)
            {
                if (File.Exists(file))
                    File.Delete(file);
            }
        }
