    public class MyClass
    {
        public MyClass()
        {
            var disp = new BucketDispenser();
            Widget widget = disp.Dispense<Widget>("widget");
            OtherWidget otherWidget = disp.Dispense<OtherWidget>("otherWidget");
        }
     }
