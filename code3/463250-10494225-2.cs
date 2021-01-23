    public class AutoHttpMocksDataAttribute : AutoDataAttribute
    {
        public AutoHttpMocksDataAttribute()
            : base(new Fixture().Customize(new HttpMocksCustomization()))
        {
        }
    }
