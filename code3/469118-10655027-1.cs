    using System;
    using System.Collections.Generic;
    using System.Linq;
    namespace ConsoleApplication3
    {
        class Program
        {
            static void Main(string[] args)
            {
                using (PropertyLessClass plc = new PropertyLessClass())
                {
                    plc.SetProperty("age", 25);
                    plc.SetProperty("name", "John");
                    Console.WriteLine("Age: {0}", plc.GetProperty("age"));
                    Console.WriteLine("Name: {0}", plc.GetProperty("name"));
                }
                Console.ReadLine();
            }
        }
    }
    public class PropertyLessClass : IDisposable
    {
        public void Dispose()
        {
            this.DeleteProperties();
        }
    }
    public static class PropertyStore
    {
        private static Dictionary<WeakReference, Dictionary<string, object>> store
            = new Dictionary<WeakReference, Dictionary<string, object>>();
        
        public static void SetProperty(this object o, string property, object value)
        {
            var key = store.Keys.FirstOrDefault(wr => wr.IsAlive && wr.Target == o);
            if (key == null)
            {
                key = new WeakReference(o);
                store.Add(key, new Dictionary<string, object>());
            }
            store[key][property] = value;
        }
        public static object GetProperty(this object o, string property)
        {
            var key = store.Keys.FirstOrDefault(wr => wr.IsAlive && wr.Target == o);
            if (key == null)
            {
                return null; // or throw Exception
            }
            if (!store[key].ContainsKey(property))
                return null; // or throw Exception
            return store[key][property];
        }
        public static void DeleteProperties(this object o)
        {
            var key = store.Keys.FirstOrDefault(wr => wr.IsAlive && wr.Target == o);
            if (key != null)
            {
                store.Remove(key);
            }
        }
    }
