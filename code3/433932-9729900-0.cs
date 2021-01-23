    public class MyClass() : Dictionary<string, object>
    {
          protected MyClass(SerializationInfo info, StreamingContext context) 
              : base(info, context) // Call the constructor in Dictionary
          {
             // instantiate other properties you had added to MyClass.
          }
        
          public void GetObjectData(SerializationInfo info, StreamingContext context)
          {
            base.GetObjectData(info, context); 
            // Now add other fields that MyClass implements.
            info.AddValue("whatever", this.AnotherProperty); 
          }
    }
