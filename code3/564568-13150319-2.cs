    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Net;
    using System.Net.Sockets;
    using System.Text;
    
    namespace IrcServiceLibrary
    {
      public class IrcSession
      {    
        /// <summary>
        /// Exists to anchor sessions to prevent premature garbage collection
        /// </summary>
        public static List<IrcSession> Sessions;
        TcpClient _tcpClient;
        NetworkStream _stream;
        byte[] _bytebuf = new byte[1];
    
        /// <summary>
        /// Created dynamically to manage an Irc session. 
        /// </summary>
        /// <param name="tcpClient">The local end of the TCP connection established by a test client 
        /// to request and administer a test session.</param>
        public IrcSession(TcpClient tcpClient)
        {
          Sessions.Add(this);
          _tcpClient = tcpClient;
          _stream = _tcpClient.GetStream();
          _stream.BeginRead(_bytebuf, 0, 1, IncomingByteHandler, null);
        }
        
        void IncomingByteHandler(IAsyncResult ar)
        {
          try
          {
            //do something with the incoming byte
            //probably feed it to a state machine
          }
          finally
          {
            //restart listening AFTER digesting byte to ensure in-order delivery to this code
            _stream.BeginRead(_bytebuf, 0, 1, IncomingByteHandler, null);
          }
        }
    
      }
    }
