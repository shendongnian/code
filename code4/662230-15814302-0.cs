    [AttributeUsage(AttributeTargets.Field, Inherited = false, AllowMultiple = false)]
    internal sealed class VertebralHeightAsDoubleAttribute : Attribute
    {
      public double HeightValue { get; private set; }
      public VertebralHeightAsDoubleAttribute(double heightValue_)
      {
        HeightValue = heightValue_;
      }
    }   
