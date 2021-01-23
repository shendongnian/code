    // store this class in a file in your app_code folder called something like MyClass.cs
    public class MyClass
    {
       public string SomeStringValue;
       public int SomeIntValue;
       public List<SomeOtherClass> MyClassCollection = new List<SomeOtherClass>();
    }
    public class SomeOtherClass
    {
        public string OtherStringValue;
    }
    
    // At the beginning of your form, on your first page, instance this class
    MyClass oMyClass = new MyClass();
    
    // Then, when you collect the data on the page, set the values in the class
    oMyClass.SomeStringValue = "derp";
    
    // Then, store it on session in that page
    Session["oMyClass"] = oMyClass;
    
    // Then, on the next page, get the object from session
    MyClass oMyClass = (MyClass)Session["oMyclass"];
    
    // Then, set the next value in your object
    oMyClass.SomeIntValue = -1;
    
    // Then, place it back in session on that page, and then keep chuggin through your workflow.
    
    // Now, I didn't show you how to use MyClassCollection that is in the MyClass object, but it would be simple for you to store a class from each page in that collection like so
    SomeOtherClass oSomeOtherClass = new SomeOtherClass();
    oSomeOtherClass.OtherStringValue = "herp";
    oMyclass.MyClassCollection.Add(oSomeOtherClass);
    
    // Then you can place that collection in session
