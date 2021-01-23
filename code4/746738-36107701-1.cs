    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.ComponentModel.Composition;
    using System.ComponentModel.Composition.Hosting;
    
    [assembly: BreakVSTestFrameworkDetection]
    
    [InheritedExport]
    public interface IGenericService<T>
    {
        void Print(T thing);
    }
    
    public class SomeGenericService<T> : IGenericService<T>
    {
        public void Print(T thing) => Console.WriteLine($"{typeof(T)}:{thing}");
    }
    
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Run()
        {
            using (var catalogue = new ApplicationCatalog())
            using (var container = new CompositionContainer(catalogue))
            {
                container.GetExportedValue<IGenericService<string>>().Print("asdf"); // System.String:asdf
                container.GetExportedValue<IGenericService<int>>().Print(123); // System.Int32:123
            }
        }
    
        static void Main(string[] args) => new UnitTest1().Run();
    }
