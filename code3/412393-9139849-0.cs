    public class Storage<T> where T : IStorable
    {
     public T GetSingleByID<T>(long id)
     {
      // do some magic to return the object based on T and the id
     }
    }
