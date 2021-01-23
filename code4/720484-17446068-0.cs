    public IObservable<Message> InterpretProtocol(IObservable<message> stream) {
    
      return stream.
             TakeWhile(msg => ProtocolMessageTypeOf(message) != ProtocolMessageType.Complete).
             Select(msg => {
                 if(ProtocolMessageTypeOf(message) == ProtocolMessageType.Error)
                   throw new InvalidOperationException(message);
                 else
                   return msg;
            });
    
    }
