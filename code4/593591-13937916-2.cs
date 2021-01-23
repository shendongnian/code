        /// <include file='doc\XmlSerializationWriter.uex' path='docs/doc[@for="XmlSerializationWriter.FromByteArrayBase64"]/*' /> 
        protected static byte[] FromByteArrayBase64(byte[] value) {
            // Unlike other "From" functions that one is just a place holder for automatic code generation. 
            // The reason is performance and memory consumption for (potentially) big 64base-encoded chunks
            // And it is assumed that the caller generates the code that will distinguish between byte[] and string return types
            //
            return value; 
        }
        /// <include file='doc\XmlSerializationWriter.uex' path='docs/doc[@for="XmlSerializationWriter.FromByteArrayHex"]/*' /> 
        protected static string FromByteArrayHex(byte[] value) {
            return XmlCustomFormatter.FromByteArrayHex(value); 
        } 
        /// <include file='doc\XmlSerializationWriter.uex' path='docs/doc[@for="XmlSerializationWriter.FromDateTime"]/*' /> 
        protected static string FromDateTime(DateTime value) {
            return XmlCustomFormatter.FromDateTime(value);
        }
 
        /// <include file='doc\XmlSerializationWriter.uex' path='docs/doc[@for="XmlSerializationWriter.FromDate"]/*' />
        protected static string FromDate(DateTime value) { 
            return XmlCustomFormatter.FromDate(value); 
        }
 
        /// <include file='doc\XmlSerializationWriter.uex' path='docs/doc[@for="XmlSerializationWriter.FromTime"]/*' />
        protected static string FromTime(DateTime value) {
            return XmlCustomFormatter.FromTime(value);
        } 
        /// <include file='doc\XmlSerializationWriter.uex' path='docs/doc[@for="XmlSerializationWriter.FromChar"]/*' /> 
        protected static string FromChar(char value) { 
            return XmlCustomFormatter.FromChar(value);
        } 
        /// <include file='doc\XmlSerializationWriter.uex' path='docs/doc[@for="XmlSerializationWriter.FromEnum"]/*' />
        protected static string FromEnum(long value, string[] values, long[] ids) {
            return XmlCustomFormatter.FromEnum(value, values, ids, null); 
        }
 
        /// <include file='doc\XmlSerializationWriter.uex' path='docs/doc[@for="XmlSerializationWriter.FromEnum1"]/*' /> 
        protected static string FromEnum(long value, string[] values, long[] ids, string typeName) {
            return XmlCustomFormatter.FromEnum(value, values, ids, typeName); 
        }
        /// <include file='doc\XmlSerializationWriter.uex' path='docs/doc[@for="XmlSerializationWriter.FromXmlName"]/*' />
        protected static string FromXmlName(string name) { 
            return XmlCustomFormatter.FromXmlName(name);
        } 
 
        /// <include file='doc\XmlSerializationWriter.uex' path='docs/doc[@for="XmlSerializationWriter.FromXmlNCName"]/*' />
        protected static string FromXmlNCName(string ncName) { 
            return XmlCustomFormatter.FromXmlNCName(ncName);
        }
        /// <include file='doc\XmlSerializationWriter.uex' path='docs/doc[@for="XmlSerializationWriter.FromXmlNmToken"]/*' /> 
        protected static string FromXmlNmToken(string nmToken) {
            return XmlCustomFormatter.FromXmlNmToken(nmToken); 
        } 
        /// <include file='doc\XmlSerializationWriter.uex' path='docs/doc[@for="XmlSerializationWriter.FromXmlNmTokens"]/*' /> 
        protected static string FromXmlNmTokens(string nmTokens) {
            return XmlCustomFormatter.FromXmlNmTokens(nmTokens);
        }
