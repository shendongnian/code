    namespace MyTopNamespace 
    { 
        namespace MyLevel2Namespace 
        {
            partial class MyTopLevelClass
            {
                partial class MyNestedClassA
                {
                    // Part of definition for our nested class:
                    // MyTopNamespace.MyLevel2Namespace.MyTopLevelClass.MyNestedClassA
                }
                class MyOtherNestedClassNotPartitioned
                {
                   ...
                }
                partial class MyNestedClassB
                {
                    // Part of definition for our nested class:
                    // MyTopNamespace.MyLevel2Namespace.MyTopLevelClass.MyNestedClassB
                }
            }
        }
    }
