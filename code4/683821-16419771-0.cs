    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace LinqTests
    {
        class Program
        {
            static void Main(string[] args)
            {
                var f1 = new F1 { F2 = new F2 { Name = "Test"}, Q = 10 };
                var f3 = new F3 { F2 = new F2() };
                Copier.Copy(f1, f3, "Q");
                Copier.Copy(f1, f3, "F2.Name");
    
            }
    
            static class Copier
            {
                public static void Copy(object source, object destination, string navigationPath)
                {
                    var sourceValuePointHandle = GetValuePointHandle(source, navigationPath);
                    var destinationValuePointHandle = GetValuePointHandle(destination, navigationPath);
                    destinationValuePointHandle.SetValue(sourceValuePointHandle.GetValue());
                }
    
                private static ValuePointHandle GetValuePointHandle(object instance, string navigationPath)
                {
                    var propertyName = new String(navigationPath.TakeWhile(x => x != '.').ToArray());
                    var property = instance.GetType().GetProperty(propertyName);
    
                    if (propertyName.Length != navigationPath.Length)
                    {
                        var propertyInstance = property.GetValue(instance, null);
                        return GetValuePointHandle(propertyInstance, navigationPath.Substring(propertyName.Length + 1, navigationPath.Length - propertyName.Length - 1));
                    }
                    else
                        return new ValuePointHandle(instance, property);
                }
    
                class ValuePointHandle
                {
                    public object Instance
                    {
                        get;
                        private set;
                    }
    
                    public PropertyInfo Property
                    {
                        get;
                        private set;
                    }
    
                    public ValuePointHandle(object instance, PropertyInfo property)
                    {
                        Instance = instance;
                        Property = property;
                    }
    
                    public void SetValue(object value)
                    {
                        Property.SetValue(Instance, value, null);
                    }
    
                    public object GetValue()
                    {
                        return Property.GetValue(Instance, null);
                    }
                }
            }
    
            class F1
            {
                public int Q
                {
                    get;
                    set;
                }
    
                public F2 F2
                {
                    get;
                    set;
                }
            }
    
            class F2
            {
                public string Name
                {
                    get;
                    set;
                }
            }
    
            class F3
            {
                public int Q
                {
                    get;
                    set;
                }
    
                public F2 F2
                {
                    get;
                    set;
                }
            }
        }
        
    }
    
      
