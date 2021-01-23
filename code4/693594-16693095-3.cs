    public class DescriptionMap : ClassMap<Description>
    {
      public DescriptionMap ()
      {
        Id(x => x.Id);
        Map(x => x.Suggestion);
        Map(x => x.Composition);
      }
    }
