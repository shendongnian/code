      public IEnumerable<Signal> Signals
      {
        get
        {
          return from signal in Signals
          from ms in MessageSignals
          where ms.MessageId == this.MessageId && ms.SignalId==signal.Id
          select signal;
        }
      }
