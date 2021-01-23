    public string Prop {
      get { return ...; }
      set { if (!(this is MessageHandler<TMessage>)) 
               throw Exception(...);
            .... setter code;
      }
    }
