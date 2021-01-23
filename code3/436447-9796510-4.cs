    public class PublicDto {
          public Guid userGuid { get; set; }
          public Dictionary<string,string> Prop { get; }
          public PublicDto ()
          {
              Prop = new Dictionary<string,string>();
          }
    }
