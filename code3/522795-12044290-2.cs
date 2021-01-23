    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Net;
    using System.Net.NetworkInformation;
    using System.Text;
    
    namespace FileEventReaderUI.Services.Network
    {
        class ListenerProcessInformation
        {
            private string _fileName;
            private string[] _processModules;
            private IPEndPoint _localEndPoint;
            private IPEndPoint _remoteEndPoint;
            private int _processId;
            private TcpState _state;
    
            public ListenerProcessInformation(string fileName, string[] processModules, IPEndPoint localEndPoint, IPEndPoint remoteEndPoint, int processId, TcpState state)
            {
                _fileName = fileName;
                _processModules = processModules;
                _localEndPoint = localEndPoint;
                _remoteEndPoint = remoteEndPoint;
                _processId = processId;
                _state = state;
            }
    
            public string FileName
            {
                get { return _fileName; }
            }
    
            public string[] ProcessModules
            {
                get { return _processModules; }
            }
    
            public IPEndPoint LocalEndPoint
            {
                get { return _localEndPoint; }
            }
    
            public IPEndPoint RemoteEndPoint
            {
                get { return _remoteEndPoint; }
            }
    
            public int ProcessId
            {
                get { return _processId; }
            }
    
            public TcpState State
            {
                get { return _state; }
            }
        }
    }
