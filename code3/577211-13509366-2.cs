    public class AutoConventionDataAttribute : AutoDataAttribute
    {
        public AutoConventionDataAttribute()
            : base(new Fixture().Customize(new TestConventions()))
        {
        }
    }
