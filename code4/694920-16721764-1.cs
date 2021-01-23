    // Assembly and module
    [assembly: AttributesTest.MyAnnotation("Assembly")]
    
    [module: AttributesTest.MyAnnotation("Module")]
    
    namespace AttributesTest
    {
        // The attribute
        [System.AttributeUsage(System.AttributeTargets.All, AllowMultiple = true)]
        public sealed class MyAnnotationAttribute : System.Attribute
        {
            public string Param { get; private set; }
            public MyAnnotationAttribute(string param) { Param = param; }
        }
    
        // Types
        [MyAnnotation("Class")]
        public class SomeClass { }
    
        [MyAnnotation("Delegate")]
        public delegate int SomeDelegate(string s, float f);
    
        [MyAnnotation("Enum")]
        public enum SomeEnum { ValueOne, ValueTwo }
    
        [MyAnnotation("Interface")]
        public interface SomeInterface { }
    
        [MyAnnotation("Struct")]
        public struct SomeStruct { }
    
        // Members
        public class MethodsExample
        {
            [MyAnnotation("Constructor")]
            public MethodsExample() { }
    
            [MyAnnotation("Method")]
            public int SomeMethod(short s) { return 42 + s; }
    
            [MyAnnotation("Field")]
            private int _someField;
    
            [MyAnnotation("Property")]
            public int SomeProperty {
                [MyAnnotation("Method")] get { return _someField; }
                [MyAnnotation("Method")] set { _someField = value; }
            }
    
            private SomeDelegate _backingField;
    
            [MyAnnotation("Event")]
            public event SomeDelegate SomeEvent {
                [MyAnnotation("Method")] add { _backingField += value; }
                [MyAnnotation("Method")] remove { _backingField -= value; }
            }
        }
    
        // Parameters
        public class ParametersExample<T1, [MyAnnotation("GenericParameter")]T2, T3>
        {
            public int SomeMethod([MyAnnotation("Parameter")]short s) { return 42 + s; }
        }
    
        // Return value
        public class ReturnValueExample
        {
            [return: MyAnnotation("ReturnValue")]
            public int SomeMethod(short s) {
                return 42 + s;
            }
        }
    }
