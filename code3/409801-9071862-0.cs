        public class Logger
        { 
          private static Logger instance=null;
          // private constructor
          private Logger()
          {
          }
          /// <summary>
        /// Gets an instance with default parameters based upon the caller
        /// </summary>
        /// <returns></returns>
        public static Logger GetInstance()
        {
           // make sure you return single instance
           if (instance == null)
            {
                instance=new Logger();
                return instance;
            }
            else
                return instance;
        }
       }
