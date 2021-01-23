    private static Parent Clone(Parent parent)
    {
        Parent parentClone = null;
        lock (m_lock) // serialize cloning.
        {
            IFormatter formatter = new BinaryFormatter();
            MemoryStream stream = new MemoryStream();
            using (stream)
            {
                formatter.Serialize(stream, parent);
                stream.Seek(0, SeekOrigin.Begin);
                parentClone = (Parent)formatter.Deserialize(stream);
            }
        }
        return parentClone;
    }
