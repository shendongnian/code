     //deserializes the variable m_settings to make the data persistant
            public override bool Write(GH_IWriter writer)
            {
                if (m_settings != null && m_settings.Length > 0)
                {
                    writer.SetInt32("StringCount", m_settings.Length);
                    for (int i = 0; i < m_settings.Length; i++)
                    {
                        writer.SetString("String", i, m_settings[i]);
                    }
                }
    
                return base.Write(writer);
            }
    
            //deserializes the variable m_settings to make the data persistant
            public override bool Read(GH_IReader reader)
            {
                m_settings = null;
    
                int count = 0;
                reader.TryGetInt32("StringCount", ref count);
                if (count > 0)
                {
                    System.Array.Resize(ref m_settings, count);
                    for (int i = 0; i < count; i++)
                    {
                        string line = null;
                        reader.TryGetString("String", i, ref line);
                        m_settings[i] = line;
                    }
                }
    
                return base.Read(reader);
            }
