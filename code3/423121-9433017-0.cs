        public void ExecuteTryCatch<T>(Action<T> action, T genericParameter)
        {
            try
            {
                action.Invoke(genericParameter);
            }
            catch (Exception e)
            {
                //Do Logging
            }
        }
