    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Text;
    using System.ServiceModel.Channels;
    using System.ServiceModel;
    
    namespace your_namespace
    {
      
        public class CredentialsHelper
        {
    	   // siple string is for example - you can use your data structure here
            private static readonly string CredentialsHeaderName = "MyCredentials";
            private static readonly string CredentialsHeaderNamespace = "urn:Urn_probably_like_your_namespance";
    
            /// <summary>
            /// Update message with credentials
            /// </summary>
            public static Message AddCredentialsHeader(ref Message request)
            {
              
    		  string user = "John";
    		  string password = "Doe";
    		  
                string cred = string.Format("{0},{1}",   user, password);
    
                // Add header
                MessageHeader<string> header = new MessageHeader<string>(callerDetails);
                MessageHeader untyped = header.GetUntypedHeader(CredentialsHeaderName, CredentialsHeaderNamespace);
    
                request = request.CreateBufferedCopy(int.MaxValue).CreateMessage();
                request.Headers.Add(untyped);
    
                return request;
            }
    
            /// <summary>
            /// Get details of current credentials from client-side added incoming headers
            /// 
            /// Return empty credentials when empty credentials specified 
            /// or when exception was occurred
            /// </summary>
            public static string GetCredentials()
            {
                string credentialDetails = string.Empty;
                try
                {
                    credentialDetails = OperationContext.Current.IncomingMessageHeaders.
                        GetHeader<string>
                            (CredentialsHeaderName, CredentialsHeaderNamespace);
                }
                catch
                {
    					// TODO: ...
                }
                return credentialDetails;
            }
    
        }
    }
