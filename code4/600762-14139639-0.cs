    [AttributeUsage(AttributeTargets.Class)]
        public class SampleClass : Attribute {
            public SampleClass() : base() { }
            public SampleClass(YourEnum attributeValue) : this() { MyAttributeProperty = attributeValue; }
            public YourEnum MyAttributeProperty { get; set; }
        }
    
        public enum YourEnum { Value1, Value2, Value3 }
    
        [SampleClass(YourEnum.Value1)]
        public class ExampleValue1Class { }
    
        public class LoadOnlyClassesWithEnumValue1 {
            public LoadOnlyClassesWithEnumValue1() {
    
                Type[] allTypes = Assembly.GetExecutingAssembly().GetExportedTypes();
                foreach (var type in allTypes) {
                    if (type.GetCustomAttributes(typeof(SampleClass), false).Length > 0) {
                        SampleClass theAttribute = type.GetCustomAttributes(typeof(SampleClass), false).Single() as SampleClass;
                        // this type is using SampleClass - I use .Single() cause I don't expect multiple SampleClass attributes, change ths if you want
                        // specify true instead of false to get base class attributes as well - i.e. ExampleValue1Class inherits from something else which has a SampleClass attribute
                        switch (theAttribute.MyAttributeProperty) {
                            case YourEnum.Value1:
                                // Do whatever
                                break;
                            case YourEnum.Value2:
                                // you want
                                break;
                            case YourEnum.Value3:
                            default:
                                // in your switch here
                                // You'll find the ExampleValue1Class object should hit the Value1 switch
                                break;
                        }
                    }
                }
            }
        }
