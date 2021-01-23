    public class container // instanciated so name is not so relevant 
    {                      // e.g : container c = new container()
                           // usag- c.utils.......
        public static class utils // used from an instance of container
        {
          public static int Str2int(string strToConvert)
          {
              return Convert.ToInt32(StrToConvert);
          }
        }
    }
