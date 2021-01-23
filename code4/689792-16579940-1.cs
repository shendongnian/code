    using System;
    using System.Reflection;
    
    public delegate void PropertyChangedDelegate<OwnerType, PropertyType>(OwnerType sender, PropertyType oldValue, PropertyType newValue);
    
    public class EventObject
    {
        public event PropertyChangedDelegate<Object, Boolean> PropertyChanged;
        public event PropertyChangedDelegate<Object, Int32> XChanged;
        
        public void RaisePropertyChanged() {
            PropertyChanged(this, true, false);
        }
    }
    
    class Test {
    
        static void Main()
        {
            EventObject eventObject = new EventObject();
            EventInfo eventInfo = eventObject.GetType().GetEvent("PropertyChanged"); 
            Type evType = eventInfo.EventHandlerType;
            // replace below with this.GetType() in case of instance method
            Type thisType = typeof(Test); 
            MethodInfo mi = thisType.GetMethod("PropertyChanged", BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static);
            MethodInfo genericMi = mi.MakeGenericMethod(evType.GetGenericArguments());
            Delegate del = Delegate.CreateDelegate(evType, genericMi);
            eventInfo.AddEventHandler(eventObject, del);
            // Test
            eventObject.RaisePropertyChanged();
        }
    
        static void PropertyChanged<TOwner, T>(TOwner obj, T oldValue, T newValue)
        {
            Console.WriteLine("-- Invoked --");
        }
    }
