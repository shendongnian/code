    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using Microsoft.Build.Framework;
    using Microsoft.Build.Utilities;
    
    namespace TaskClass
    {
        // Class to be created
        public class MyDbContext
        {
            public int ConstructorArg1 { get; set; }
            public string ConstructorArg2 { get; set; }
    
            public MyDbContext() { }
    
            public MyDbContext(int constructorArg1)
            {
                ConstructorArg1 = constructorArg1;
            }
    
            public MyDbContext(int constructorArg1, string constructorArg2)
            {
                ConstructorArg1 = constructorArg1;
                ConstructorArg2 = constructorArg2;
            }       
        }
        
        // MSBuild custom task
        public class DoSomethingTask : Task
        {
            public override bool Execute()
            {
                var taskParameters = new TaskParametersInfo();
                taskParameters.ExtractTaskParametersInfo(this);
                                       
                var type = typeof(MyDbContext);
                ConstructorInfo ctor = type.GetConstructor(taskParameters.Types.ToArray());
    
                if (ctor == null)
                {
                    // If the constructor is not found, throw an error
                    Log.LogError("There are no constructors defined with these parameters.");
                    return false;
                }
                            
                // Create your instance
                var myDbContext = (MyDbContext)ctor.Invoke(taskParameters.Values.ToArray());
                           
                return true;
            }
                  
            public int ConstructorArg1
            {
                get;
                set;
            }
    
            public string ConstructorArg2
            {
                get; 
                set;
            }
    
            public string ConstructorArg3
            { 
                get; 
                set; 
            }
    
            // Class to handle the task's parameters
            internal class TaskParametersInfo
            {
                public List<Type> Types { get; set; }
                public List<object> Values { get; set; }
    
                public TaskParametersInfo()
                {
                    Types = new List<Type>();
                    Values = new List<object>();
                }
    
                public void ExtractTaskParametersInfo(Task task)
                {
                    foreach (var property in task.GetType().GetProperties(BindingFlags.Public | BindingFlags.DeclaredOnly | BindingFlags.Instance))
                    {
                        var propertyValue = property.GetValue(task, null);
                        if (propertyValue != null)
                        {
                            Types.Add(property.PropertyType);
                            Values.Add(propertyValue);
                        }
                    }
                }
            }
        }
    }
