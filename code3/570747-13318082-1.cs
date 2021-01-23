    using System;
    using System.Reflection;
    using System.Collections.Generic;
    namespace StackOverflow.Demos
    {
        class Program
        {
            public static void Main(string[] args) 
            {
                object o = new object();
                Console.WriteLine(ExtensionDetectorT<string,object>.IsExtensionMethod(o.ToString));
                Console.WriteLine(ExtensionDetectorT<string, object>.IsExtensionMethod(o.ToString2));
                Console.WriteLine(ExtensionDetectorT<bool, object>.IsExtensionMethod(o.Equals));
                Console.WriteLine(ExtensionDetectorT<bool, object>.IsExtensionMethod(o.Equals2));
                Console.WriteLine(ExtensionDetectorVoid<object>.IsExtensionMethod(o.DoNothing));
                Console.WriteLine(ExtensionDetectorVoid<int>.IsExtensionMethod(o.DoNothing2));
                Console.WriteLine("Done");
                Console.ReadKey();
            }
        }
        public static class ExtensionDetectorT<TReturn,TParam1>
        {
            public delegate TReturn ExtensionMethodDelegateT();
            public delegate TReturn ExtensionMethodDelegateT2(TParam1 ignoreMe);
            public static bool IsExtensionMethod(ExtensionMethodDelegateT emd)
            {
                return !(new List<MethodInfo>(emd.Target.GetType().GetMethods())).Exists(delegate(MethodInfo mi) { return mi.Name.Equals(emd.Method.Name); });
            }
            public static bool IsExtensionMethod(ExtensionMethodDelegateT2 emd)
            {
                return !(new List<MethodInfo>(emd.Target.GetType().GetMethods())).Exists(delegate(MethodInfo mi) { return mi.Name.Equals(emd.Method.Name); });
            }
        }
        public static class ExtensionDetectorVoid<TParam1>
        {
            public delegate void ExtensionMethodDelegateVoid();
            public delegate void ExtensionMethodDelegateVoid2(TParam1 ignoreMe);
            public static bool IsExtensionMethod(ExtensionMethodDelegateVoid emd)
            {
                return !(new List<MethodInfo>(emd.Target.GetType().GetMethods())).Exists(delegate(MethodInfo mi) { return mi.Name.Equals(emd.Method.Name); });
            }
            public static bool IsExtensionMethod(ExtensionMethodDelegateVoid2 emd)
            {
                return !(new List<MethodInfo>(emd.Target.GetType().GetMethods())).Exists(delegate(MethodInfo mi) { return mi.Name.Equals(emd.Method.Name); });
            }
        }
        public static class ObjectExtensions
        {
            public static string ToString2(this object o) { return o.ToString(); }
            public static bool Equals2(this object o, object o2) { return o.Equals(o2); }
            public static void DoNothing(this object o) { }
            public static void DoNothing2(this object o, int i) { i++; }
        }
    }
