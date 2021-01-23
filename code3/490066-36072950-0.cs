    namespace MyApplication
    {
        using log4net.Layout;
        
        public class MyConcretePatternLayout : PatternLayout
        {
            public override string Header => "My Header text here"
        }
    }
