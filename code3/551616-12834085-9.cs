    public class AccountWriter : IDisposable
    {
        private XmlWriter _writer;
        private XmlSerializer _ser;
        private XmlSerializerNamespaces _namespaces;
    
        private bool _wroteHeader = false;
        private bool _disposed = false;
        
        public bool IsDisposed { get { return _disposed; } }
    
        public AccountWriter(TextWriter target)
        {
            _namespaces = new XmlSerializerNamespaces();
            _namespaces.Add("", "");
            
            _ser = new XmlSerializer(typeof(Account));
        
            _writer = XmlWriter.Create(target);
        }
        
        public void Write(Account acct)
        {
            if (_disposed) throw new ObjectDisposedException("AccountWriter");
            
            if (!_wroteHeader)
            {
                _writer.WriteStartElement("BillingFile");
                _wroteHeader = true;
            }
            
            _ser.Serialize(_writer, acct, _namespaces);
        }
        
        public void Flush()
        {
            if (_disposed) throw new ObjectDisposedException("AccountWriter");
            _writer.Flush();
        }
        
        public void Dispose()
        {
            if (!_disposed)
            {
                if (_wroteHeader)
                {
                    _writer.WriteEndElement();
                    _writer.Dispose();
                    _wroteHeader = true;
                }
                
                _disposed = true;
            }
        }
    }
