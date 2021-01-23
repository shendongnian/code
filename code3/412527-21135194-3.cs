    namespace MyTopNamespace 
    { 
        namespace MyLevel2Namespace 
        {
            public partial class MyTopLevelClass
            {
                public partial class MyNestedClassA
                {
                   // The fully specified type is:
                   // MyTopNamespace.MyLevel2Namespace.MyTopLevelClass.MyNestedClassA
                   ... some code for our nested class 'A' ...
                }
                public class MyOtherNestedClassNotPartitioned
                {
                   ...
                }
                public partial class MyNestedClassB
                {
                    // The fully specified type is:
                    // MyTopNamespace.MyLevel2Namespace.MyTopLevelClass.MyNestedClassB
                    ... some code for our nested class 'B' ...
                }
            }
        }
    }
