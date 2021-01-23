    public class XMLTYPE4Factory : IEnvelopeFactory {
    
        public XMLTYPE4 m_XMLTYPE4;
    
        public XMLTYPE4Factory()
        {
    
        }
    
        ~XMLTYPE4Factory()
        {
    
        }
    
        public override void Dispose()
        {
    
        }
    
        /// <summary>
        /// Parsing
        /// </summary>
        /// <param name="input"></param>
        public override Envelope Parse(string input, out string envStr)
        {
    envStr= null;
            return null;
        }
    
        /// <summary>
        /// Formatting
        /// </summary>
        /// <param name="env"></param>
        public override string Format(Envelope env, out string envStr)
        {
            envStr = null;
            return "";
        }
    
    }
