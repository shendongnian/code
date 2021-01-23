    void IndentWrite(int indent, string value)
    {
        if (indent > 0)
        {
           if (s_TabArray == null)
           {
             s_TabArray = new char[MaxIndent];
             for (int i=0; i<MaxIndent; i++) s_TabArray[i]='\t';
           }
           m_writer.Write(s_TabArray, 0, indent);
        }
        m_writer.Write(value);
        m_writer.Write('\n');
    }
