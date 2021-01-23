        public static void Execute<TType>(Action<TType> OnSuccess) 
             where TType : Myclass // gets rid of unnecessary type-casts - or you just use Action<Myclass> directly - without the generic parameter...
        { 
             // throw an exception or just do nothing - it's up to you...
             if (OnSuccess == null)
                 throw new ArgumentNullException("OnSuccess"); // return;
             TType result = new Myclass() { ID = 123 };
             OnSuccess(result);
        }
        public static void Execute(Action OnSuccess) 
        { 
            if (OnSuccess == null)
                throw new ArgumentNullException(); // return;
            OnSuccess();            
        }
