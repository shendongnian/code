    Dim s As System.Xml.Serialization.XmlSerializer
            Using fs As New IO.FileStream(thePath, FileMode.Create, FileAccess.Write, FileShare.Write)
                Using w As System.Xml.XmlTextWriter = New System.Xml.XmlTextWriter(fs, System.Text.Encoding.Default)
                    s = New System.Xml.Serialization.XmlSerializer(GetType(T))
                    w.Formatting = Xml.Formatting.Indented
                    s.Serialize(w, m_objectToSerialize)
                End Using
            End Using
