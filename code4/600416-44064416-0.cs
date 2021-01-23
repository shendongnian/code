    using System;
    using System.Reflection;
    
    namespace GenericPropertyExample
    {
        //Declaring a Sample Class 
        public class class1
        {
            public string prop1 { get; set; }
            public string prop2 { get; set; }
    
        }
        public class Program
        {
            public static void Main(string[] args)
            {
                //Creating Class Object
                class1 objClass1 = new class1 { prop1 = "value1", prop2 = "value2" };
    
                //Passing Class Object to GenericPropertyFinder Class
                GenericPropertyFinder<class1> objGenericPropertyFinder = new GenericPropertyFinder<class1>();
                objGenericPropertyFinder.PrintTModelPropertyAndValue(objClass1);
                Console.ReadLine();
            }
    
            //Declaring a Generic Handler Class which will actually give Property Name,Value for any given class.
            public class GenericPropertyFinder<TModel> where TModel : class
            {
                public void PrintTModelPropertyAndValue(TModel tmodelObj)
                {
                    //Getting Type of Generic Class Model
                    Type tModelType = tmodelObj.GetType();
    
                    //We will be defining a PropertyInfo Object which contains details about the class property 
                    PropertyInfo[] arrayPropertyInfos = tModelType.GetProperties();
    
                    //Now we will loop in all properties one by one to get value
                    foreach (PropertyInfo property in arrayPropertyInfos)
                    {
                        Console.WriteLine("Name of Property is\t:\t" + property.Name);
                        Console.WriteLine("Value of Property is\t:\t" + property.GetValue(tmodelObj).ToString());
                        Console.WriteLine(Environment.NewLine);
                    }
                }
            }
        }
    }
