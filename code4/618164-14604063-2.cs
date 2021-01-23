    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Reflection;
    using System.Threading;
    namespace emit
    {
    public class Program
    {
        private static void Main()
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-GB");
            try
            {
                TestProxy();
                Console.WriteLine("OK");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            Console.ReadLine();
        }
        private static void TestProxy()
        {
            var obj = Proxy.Of<TestClass>(new CallHandler(), typeof(IInterface1), typeof(IInterface2));
            obj.MethodVoid();
            Console.WriteLine();
            Console.WriteLine(obj.PublicSquare(3));
            Console.WriteLine();
            Console.WriteLine(obj.MethodString());
            Console.WriteLine();
            Console.WriteLine(obj.MethodInt());
            Console.WriteLine();
            Console.WriteLine(obj.MethodComplex(45, " Deneme ", new Ogrenci { Name = "Ali" }).Name);
            Console.WriteLine();
            obj.PropInt = 78;
            Console.WriteLine();
            Console.WriteLine(obj.PropInt);
            Console.WriteLine();
            var int1 = obj as IInterface1;
            int1.Name = "Interface";
            Console.WriteLine();
            Console.WriteLine("Got: " + int1.Name);
            Console.WriteLine();
            int1.Name = "Interface333";
            Console.WriteLine();
            Console.WriteLine("Got3: " + int1.Name);
            Console.WriteLine();
            Console.WriteLine(int1.MethodString(34, "Par", new Ogrenci { Name = "Veli" }));
            var int2 = obj as IInterface2;
            int2.Value = 14;
            Console.WriteLine();
            Console.WriteLine("Got: " + int2.Value);
            Console.WriteLine();
            int2.Value = 333;
            Console.WriteLine();
            Console.WriteLine("Got3: " + int2.Value);
            Console.WriteLine();
            Console.WriteLine(int2.MethodInt(34, "Par", new Ogrenci { Name = "Veli" }));
            Console.WriteLine();
            obj.ThrowException();
        }
    }
    public class CallHandler : ICallHandler
    {
        private readonly SortedDictionary<string, object> _propertyValues = new SortedDictionary<string, object>();
        public object BeforeMethodCall(object obj, MethodInfo mi, object[] args)
        {
            WriteParameterInfo(mi, args);
            return SetReturnValue(mi, args);
        }
        public void AfterMethodCall(object obj, MethodInfo mi, object[] args, object returnValue)
        {
            if (mi.ReturnType == typeof(void))
                Console.WriteLine(mi.Name + " returns [void]");
            else
                Console.WriteLine(mi.Name + " returns [" + (returnValue ?? "null") + "]");
        }
        public void OnError(object obj, MethodInfo mi, object[] args, Exception exception)
        {
            Console.WriteLine("Exception Handled: " + exception.Message);
            throw new ApplicationException(exception.Message, exception);
        }
        private object SetReturnValue(MethodInfo mi, object[] args)
        {
            object res = null;
            if (mi.Name.StartsWith("get_"))
            {
                var propName = mi.Name.Replace("get_", "");
                if (_propertyValues.ContainsKey(propName))
                    res = _propertyValues[propName];
            }
            else if (mi.Name.StartsWith("set_"))
            {
                var propName = mi.Name.Replace("set_", "");
                if (!_propertyValues.ContainsKey(propName))
                    _propertyValues.Add(propName, args[0]);
                else
                    _propertyValues[propName] = args[0];
            }
            else if (mi.IsAbstract && mi.ReturnType != typeof(void))
            {
                res = mi.ReturnType.GetDefaultValue();
                var methodName = mi.Name;
                if (!_propertyValues.ContainsKey(methodName))
                    _propertyValues.Add(methodName, res);
                else
                    _propertyValues[methodName] = res;
            }
            if (mi.ReturnType == typeof(void))
                Console.WriteLine(mi.Name + " should return [void]");
            else
                Console.WriteLine(mi.Name + " should return [" + res + "]");
            return res;
        }
        private void WriteParameterInfo(MethodInfo mi, object[] args)
        {
            Console.Write(mi.Name + " takes ");
            if (args.Length == 0)
            {
                Console.WriteLine("no parameter");
            }
            else
            {
                Console.WriteLine("{0} parameter(s)", args.Length);
                var paramInfos = mi.GetParameters();
                for (int i = 0; i < args.Length; i++)
                {
                    Console.WriteLine("\t[{0} {1}: '{2}']", paramInfos[i].ParameterType.Name, paramInfos[i].Name, args[i]);
                }
            }
        }
    }
    public interface IInterface1
    {
        string Name { get; set; }
        string MethodString(int i, string s, object o);
    }
    public interface IInterface2
    {
        int Value { get; set; }
        int MethodInt(int i, string s, Ogrenci o);
    }
    public class TestClass
    {
        public virtual int PropInt { get; set; }
        public virtual void ThrowException()
        {
            throw new Exception("Custom Error");
        }
        protected virtual double ProtectedSquare(int x)
        {
            Console.WriteLine("Executing Method ProtectedSquare");
            return x * x;
        }
        public virtual double PublicSquare(int x)
        {
            Console.WriteLine("Executing Method PublicSquare");
            return ProtectedSquare(x);
        }
        public virtual string MethodString()
        {
            Console.WriteLine("Executing String Method");
            return "Hele";
        }
        public virtual int MethodInt()
        {
            Console.WriteLine("Executing Int Method");
            return 985;
        }
        public virtual void MethodVoid()
        {
            Console.WriteLine("Executing Void Method");
        }
        public virtual Ogrenci MethodComplex(int x, string f, Ogrenci o)
        {
            Console.WriteLine("Executing Parameter Method");
            return new Ogrenci { Name = o.Name + x + f };
        }
    }
    public class Ogrenci
    {
        public string Name { get; set; }
        public override string ToString()
        {
            return Name;
        }
    }
    }
