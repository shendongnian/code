        BinaryFormatter m_formatter;
        Byte[] m_stateData;
        List<T> cloned_objList;
        public binaryserializer(List<T> PlayersOnBench)
        {
            if ((!Object.ReferenceEquals(listToClone, null)) && (typeof(T).IsSerializable))
            {
                m_formatter = new BinaryFormatter();
                using (MemoryStream stream = new MemoryStream())
                {
                    try
                    {
                        m_formatter.Serialize(stream, PlayersOnBench);
                    }
                    catch { }
                    stream.Seek(0, SeekOrigin.Begin);
                    m_stateData = stream.ToArray();
                }
            }
        }
        public List<T> BenchStates
        {
            get
            {
                using (MemoryStream stream = new MemoryStream(m_stateData))
                {
                    try
                    {
                        cloned_objList = (List<T>)m_formatter.Deserialize(stream);
                    }
                    catch (Exception) { }
                }
                return cloned_objList;
            }
        }
