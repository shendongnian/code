private static PrintStringDataBuilder _instance = null;
private static object _lockObject = new object();
public static PrintStringDataBuilder GetInstance()
{
    if(_instance == null)
    {
         lock(_lockObject)
         {
              if(_instance == null)
              {
                 var temp = new PrintStringDataBuilder();
                 Interlocked.Exchange(ref _instance, temp);
              }
         }
    }
    return _instance;
}
