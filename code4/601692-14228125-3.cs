    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Linq.Expressions;
    using System.Xml.Linq;
    using System.Runtime.InteropServices;
    
    namespace Bad
    {
        class Program
        {
            static void Main(string[] args)
            {
                Action a = () => Console.WriteLine("test");
                Horror h = new Horror();
                h.Fix(new Big(), ref a, new Big());
                h.Clear();
                Console.WriteLine();
            }
        }
        [StructLayout(LayoutKind.Sequential, Size = 4096)]
        struct Big
        {
        }
        unsafe class Horror
        {
            void* _ptr;
    
            static void Handler()
            {
                Console.WriteLine("Hello world.");
            }
    
    
            public void Fix(Big big, ref Action action, Big big2)
            {
                action += Handler;
                var tr = __makeref(action);
                _ptr = (void*)&tr;
            }
    
            public void Clear()
            {
                var tr = *(TypedReference*)_ptr;
                __refvalue(tr, Action) -= Handler;
            }
        }
    }
