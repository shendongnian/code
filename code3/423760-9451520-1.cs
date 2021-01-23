      public PipeClient(string pipeName)
        {
            _pipeClient = new NamedPipeClientStream(".", pipeName, PipeDirection.In);
            _pipeClient.Connect();
            _streamReader = new StreamReader(_pipeClient);
        }
      public void ReadMessages()
        {
            string temp;
        
            
                while ((temp = _streamReader.ReadLine()) != null)
                    if(MessageReadEvent != null)
                        MessageReadEvent(temp);
        }
