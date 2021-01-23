      public int Count {
            get {
                Contract.Ensures(Contract.Result<int>() >= 0);
                return _size; 
            }
        }
