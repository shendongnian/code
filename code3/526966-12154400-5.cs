    internal abstract class BatchSource : IBatchSource
    {
        private string m_content;
        public void Populate()
        {
            m_content = GetContent();
        }
        public void Reset()
        {
            m_content = null;
        }
        protected abstract string GetContent();
        public ParserAction GetMoreData(ref string str)
        {
            str = null;
            if (m_content != null)
            {
                str = m_content;
                m_content = null;
            }
            return ParserAction.Continue;
        }
    }
    internal class FileBatchSource : BatchSource
    {
        private readonly string m_fileName;
        public FileBatchSource(string fileName)
        {
            m_fileName = fileName;
        }
        protected override string GetContent()
        {
            return File.ReadAllText(m_fileName);
        }
    }
    internal class StatementBatchSource : BatchSource
    {
        private readonly string m_statement;
        public StatementBatchSource(string statement)
        {
            m_statement = statement;
        }
        protected override string GetContent()
        {
            return m_statement;
        }
    }
