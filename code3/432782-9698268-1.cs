    public class ExtendedA : A
    {
        public void DoSomething()
        {
            // Get an instance.
            var a = Load();
            //get the type of the class
            Type type = a.GetType();
            BindingFlags bindingFlags = BindingFlags.Instance | BindingFlags.NonPublic;
            // get the field info
            FieldInfo finfo = type.GetField("Something", bindingFlags);
            // set the value 
            finfo.SetValue(a, "Hello World!");
            
            // get the value
            object someThingField = finfo.GetValue(a);
        }
    }
