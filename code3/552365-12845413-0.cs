    @functions
    {
        private Test GetTestAttribute(object obj)
        {
            // TODO: This returns null if TestAttribute was not on the class
            TestAttribute myAttribute =
                Attribute.GetCustomAttribute(obj, typeof (TestAttribute)) as TestAttribute;
        }
    }
    
    <li>@GetTestAttribute(myClassInstance)</li>
