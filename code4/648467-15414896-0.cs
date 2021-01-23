    public class BaseSetDTO
    {
      public BaseSetDTO()
      {
        Set();
      }
      internal virtual void Set()
      {
        //Do your base set here with base properties
      }
    }
    public class SetDTO : BaseSetDTO
    {
      internal override void Set()
      {
        //Do a full set here
      }
    }
