    public class MyTestConventionsAttribute : AutoDataAttribute
    {
        public MyTestConventionsAttribute() :
            base(new Fixture().Customize(new MyTestConventions())
    }
