        public class Generic
        {
          public static T GetRandomValueByType<T>(T parameter)
          {
            switch(typeof(T))
            {
                case System.Int32:
                    Random r = new Random();
                    return (T)r.Next();
                case System.Guid:
                    return (T)Guid.NewGuid();
                // other cases here...
    }
          }
        }
