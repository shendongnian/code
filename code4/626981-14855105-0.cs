    class Utility
    {
        public static void Wrap(Action method, params object[] parameters)
        {
            try
            {
                //additional logging / events - see example below
                Debug.WriteLine("Entering : {0} @ {1}", method.Method.Name, DateTime.Now);
                foreach (var p in parameters)
                {
                    Debug.WriteLine("\tParameter : {0}", new object[] { p });
                }
                method();
                //additional logging / events - see example below
                Debug.WriteLine("Exiting : {0} @ {1}", method.Method.Name, DateTime.Now);
            }
            catch (Exception ex)
            {
                //Log exception
                throw;
            }
        }
        
        public static T Wrap<T>(Func<T> method, params object[] parameters)
        {
            try
            {
                //additional logging / events - see example below
                Debug.WriteLine("Entering : {0} @ {1}", method.Method.Name, DateTime.Now);
                foreach (var p in parameters)
                {
                    Debug.WriteLine("\tParameter : {0}", new object[]{p});
                }
                var retValue = method();
                //additional logging / events - see example below
                Debug.WriteLine("Exiting : {0} @ {1}", method.Method.Name, DateTime.Now);
                return retValue;
            }
            catch (Exception ex)
            {
                //Log exception
                throw;
            }
        }
    }
