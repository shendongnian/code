    using System;
    using System.IO;
    using System.Reflection;
    
    namespace ConsoleApplication13
    {
        class Program
        {
            static void Main(string[] args)
            {
                AppDomain appDomain = AppDomain.CreateDomain("foo");
    
                FooFactory fooFactory = (FooFactory)appDomain.CreateInstanceFromAndUnwrap(Assembly.GetEntryAssembly().Location, typeof(FooFactory).FullName);
    
                IFoo fooFromOtherDomain = fooFactory.CreateMeAFoo();
    
                string message = "Hello World!";
    
                Console.WriteLine("Data = {0} on AppDomain ID = {1}", message, AppDomain.CurrentDomain.Id);
    
                byte[] buffer = System.Text.Encoding.UTF8.GetBytes(message);
                fooFromOtherDomain.Post(buffer);
            }
        }
    
        public interface IFoo
        {
            void Post(byte[] data);
        }
    
        public abstract class FooBase
        {}
    
        /// <summary>
        /// This class represents your class that can't be marshaled by ref...
        /// </summary>
        public class Foo : FooBase, IFoo, IDisposable
        {
            private MemoryStream _buffer;
    
            public Foo()
            {
                this._buffer = new MemoryStream();
            }
    
            public void Post(byte[] data)
            {
                if (data == null)
                    throw new ArgumentNullException("data");
    
                this._buffer.Seek(0, SeekOrigin.End);
                this._buffer.Write(data, 0, data.Length);
    
                OnNewData();
            }
    
            private void OnNewData()
            {
                string dataString = System.Text.Encoding.UTF8.GetString(this._buffer.ToArray());
                Console.WriteLine("Data = {0} on AppDomain ID = {1}", dataString, AppDomain.CurrentDomain.Id);
            }
    
            public void Dispose()
            {
                this._buffer.Close();
            }
        }
    
        /// <summary>
        /// Wraps the non-remote Foo class and makes it remotely accessible.
        /// </summary>
        public class FooWrapper : MarshalByRefObject, IFoo
        {
            private IFoo _innerFoo;
    
            public FooWrapper(IFoo innerFoo)
            {
                this._innerFoo = innerFoo;
            }
    
            public void Post(byte[] data)
            {
                this._innerFoo.Post(data);
            }
        }
    
        /// <summary>
        /// For demo purposes to get an instance of IFoo from the other domain.
        /// </summary>
        public class FooFactory : MarshalByRefObject
        {
            public IFoo CreateMeAFoo()
            {
                Foo foo = new Foo();
                FooWrapper fooWrapper =new FooWrapper(foo);
    
                return fooWrapper;
            }
        }
    }
