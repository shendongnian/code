    namespace ConsoleApplication2
    {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    internal class Program
    {
        private static void Main(string[] args)
        {
            EnterPoint t = new EnterPoint();
            t.BeginProcess();
        }
    }
    public class EnterPoint
    {
        public void BeginProcess()
        {
            var t = new Test(); //Object
            try
            {
                baseDllMethod m = new baseDllMethod(); //Your DLL
                m.Set(t, "X", 1); //Problem Method, this give you error
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR EN DLL METHOD");    
            }
            xyz_D der = new xyz_D(); //Derivated method
            der.Set(t, "X", 1) ; //HIDE BASE METHOD
        }
    }
    public class baseDllMethod //YOUR DLL HERE
    {
        public void Set(object obj, string prop, object value)
        {
            var propInf = obj.GetType().GetProperty(prop);
            value = Convert.ChangeType(value, propInf.PropertyType);
            propInf.SetValue(obj, value, null);
        }
    }
    public class xyz_D : baseDllMethod //Inherits
    {
        public new void Set(object obj, string prop, object value) //Hide base method
        {
            var property = obj.GetType().GetProperty(prop);
            if (property != null)
            {
                Type t = Nullable.GetUnderlyingType(property.PropertyType)
                             ?? property.PropertyType;
                object safeValue = (value == null) ? null
                                                   : Convert.ChangeType(value, t);
                property.SetValue(obj, safeValue, null);
            }
        }
    }
    public class Test //Your Object
    {
        public int? X { get; set; }
    }
}
