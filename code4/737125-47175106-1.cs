        public bool fooMethod(object caller, [CallerMemberName]string membername = "")
        {
            Type callerType = caller.GetType();
            //This returns a value depending of type and method
            return true;
        }
