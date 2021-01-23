    //partial because I take you are using a form designer.
    //and also because the class is gonna have more things than those showed here.
    //in particular the example call a method "UseFields" that I did not define.
    public partial class MyForm: form
    {
        private static bool boolField;
        private static string stringField;
        private static int intField;
        
        private void Method()
        {
             //Do something with the fields
             UseFields(boolField, stringField, intField);
             UseFields(IsBoolFieldSet, SomeString, SharedInformation.SomeInt);
        }
        //You can also wrap them in a property:
        public static bool IsBoolFieldSet
        {
            get
            {
                return boolField;
            }
            //Don't put a set if you want it to be read only
            set
            {
                return boolField;
            }
        }
        //Or declare an static property like so:
        public static string SomeString { get; set; }
    }
    //Another good option is to have this information in a separate class
    public class SharedInformation
    {
        public static int SomeInt { get; set; }        
    }
