            set 
            { 
                m_comp.SetComponentProperty("OpenRowsetVariable", value); 
                if (AccessMode == AccessMode.AM_SQLCOMMAND_VARIABLE)
                {
                    m_comp.SetComponentProperty("SqlCommandVariable", value); 
                }
                ReinitializeMetaData(); 
            } 
