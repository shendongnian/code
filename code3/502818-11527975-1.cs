        public object CallMethod(string method, params object[] args)
        {
            object result = null;
            // lines below answers your question, you must determine the types of 
            // your parameters so that the exact method is invoked. That is a must!
            Type[] types = new Type[args.Length];
            for (int i = 0; i < types.Length; i++)
            {
                if (args[i] != null)
                    types[i] = args[i].GetType();
            }
            MethodInfo _method = this.GetType().GetMethod(method, types);
            if (_method != null)
            {
                try
                {
                    _method.Invoke(this, args);
                }
                catch (Exception ex)
                {
                    // instead of throwing exception, you can do some work to return your special return value
                    throw ex;
                }
            }
            return result;
        }
