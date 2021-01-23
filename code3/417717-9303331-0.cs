    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Runtime.Versioning;
    using System.Text;
    
    namespace YourName {
    
    	// Represents a writer that makes it possible to pre-process 
    	// XML character entity escapes without them being rewritten.
    	class XmlRawTextWriter : System.Xml.XmlTextWriter {
    		public XmlRawTextWriter(Stream w, Encoding encoding)
    			: base(w, encoding) {
    		}
    
    		public XmlRawTextWriter(String filename, Encoding encoding)
    			: base(filename, encoding) {
    		}
    
    		public override void WriteString(string text) {
    			base.WriteRaw(text);
    		}
    	}
    }
