        protected DataContractJsonSerializer innerSerializer;
    
    
        public DataContractSystemJsonSerializer(Type t)
    {
      this.innerSerializer = new DataContractJsonSerializer (t);
    }
    ...
    
    }
