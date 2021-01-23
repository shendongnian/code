    public class DefaultStringLengthConvention: IPropertyConvention
    {
      public void Apply(IPropertyInstance instance)
      {
        instance.Length(250);
      }
    }
