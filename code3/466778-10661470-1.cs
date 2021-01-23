        using System;
        using System.Collections.Generic;
        using System.Linq;
        using System.Text;
        using System.ServiceModel.Channels;
        using System.IO;
        using System.Xml;
        using System.Security.Cryptography;
    
        namespace Webservices20.BindingExtensions
           {
            class UsernameExEncoderBindingElement : MessageEncodingBindingElement
            {
            MessageEncodingBindingElement inner;        
    
            public UsernameExEncoderBindingElement(MessageEncodingBindingElement inner)
            {
                this.inner = inner;            
            }
    
            public override IChannelFactory<TChannel> BuildChannelFactory<TChannel>(BindingContext context)
            {
                context.BindingParameters.Add(this);
                var res = base.BuildChannelFactory<TChannel>(context);
                return res;
            }
    
            public override bool CanBuildChannelFactory<TChannel>(BindingContext context)
            {
                var res = base.CanBuildChannelFactory<TChannel>(context);
                return res;
            }
    
            public override MessageEncoderFactory CreateMessageEncoderFactory()
            {
                return new UsernameExEncoderFactory(this.inner.CreateMessageEncoderFactory());
            }      
    
            public override MessageVersion MessageVersion
            {
                get
                {
                    return this.inner.MessageVersion;
                }
                set
                {
                    this.inner.MessageVersion = value;
                }
            }
    
            public override BindingElement Clone()
            {
                var c = (MessageEncodingBindingElement)this.inner.Clone();
                var res = new UsernameExEncoderBindingElement(c);
                return res;
            }
    
            public override T GetProperty<T>(BindingContext context)
            {
                var res = this.inner.GetProperty<T>(context);
                return res;
            }
        }
    
        class UsernameExEncoderFactory : MessageEncoderFactory
        {
            MessageEncoderFactory inner;        
            
            public UsernameExEncoderFactory(MessageEncoderFactory inner)
            {
                this.inner = inner;            
            }
    
            public override MessageEncoder Encoder
            {
                get { return new UsernameExEncoder(inner.Encoder); }
            }
    
            public override MessageVersion MessageVersion
            {
                get { return this.inner.MessageVersion; }
            }
            
        }
    
        class UsernameExEncoder : MessageEncoder
        {
            MessageEncoder inner;
    
            public override T GetProperty<T>()
            {
                return inner.GetProperty<T>();
            }
    
            public UsernameExEncoder(MessageEncoder inner)
            {
                this.inner = inner;
            }
    
            public override string ContentType
            {
                get { return this.inner.ContentType; }
            }
    
            public override string MediaType
            {
                get { return this.inner.MediaType; }
            }
    
            public override MessageVersion MessageVersion
            {
                get { return this.inner.MessageVersion; }
            }
    
            public override bool IsContentTypeSupported(string contentType)
            {
                return this.inner.IsContentTypeSupported(contentType);
            } 
    
            public override Message ReadMessage(ArraySegment<byte> buffer, BufferManager bufferManager, string contentType)
            {
                return this.inner.ReadMessage(buffer, bufferManager, contentType);
            }
    
            public override Message ReadMessage(System.IO.Stream stream, int maxSizeOfHeaders, string contentType)
            {
                return this.inner.ReadMessage(stream, maxSizeOfHeaders, contentType);
            }
    
            public override ArraySegment<byte> WriteMessage(Message message, int maxMessageSize, BufferManager bufferManager, int messageOffset)
            {   
                //load the message to dom
                var mem = new MemoryStream();
                var x = XmlWriter.Create(mem);
                message.WriteMessage(x);
                x.Flush();
                mem.Flush();
                mem.Position = 0;
                XmlDocument doc = new XmlDocument();
                doc.Load(mem);
    
                //add the missing elements
                var token = doc.SelectSingleNode("//*[local-name(.)='UsernameToken']");
                var created = doc.CreateElement("Created", "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd");
                var nonce = doc.CreateElement("Nonce", "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd");
                token.AppendChild(created);
                token.AppendChild(nonce);
    
                //set nonce value
                byte[] nonce_bytes = new byte[16];
                RandomNumberGenerator rndGenerator = new RNGCryptoServiceProvider();
                rndGenerator.GetBytes(nonce_bytes);
                nonce.InnerText = Convert.ToBase64String(nonce_bytes);
                   
                //set create value
                created.InnerText = XmlConvert.ToString(DateTime.Now.ToUniversalTime(), "yyyy-MM-ddTHH:mm:ssZ");
                
                //create a new message
                var r = XmlReader.Create(new StringReader(doc.OuterXml));
                var newMsg = Message.CreateMessage(message.Version, message.Headers.Action, r);
    
                return this.inner.WriteMessage(newMsg, maxMessageSize, bufferManager, messageOffset);
            }
    
         
    
    
            public override void WriteMessage(Message message, System.IO.Stream stream)
            {
                this.inner.WriteMessage(message, stream);
            }
        }
        }
      
