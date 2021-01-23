    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;
    namespace TestReflection
    {
        public class CustomClassAsArg
        {
            public string MyInfo { get; set; }
        }
    
        public class CallMe
        {
            public void Hello1(String msg, int i)
            {
                Console.WriteLine(msg + ": " + i.ToString());
            }
            public void Hello2(ref String msg)
            {
                msg += "out string";
            }
            public void Hello2(ref int a)
            {
                a += 2;
            }
            public string Hello3(string a)
            {
                return a + "--";
            }
            public static bool MyStaticMethod( int arg, ref String outs )
            {
                outs = "->" + arg.ToString();
                return true;
            }
            public bool? ThreeStateTest( int i )
            {
                switch ( i )
                {
                    case 0:
                        return null;
                    case 1:
                        return false;
                    case 2:
                        return true;
                }
        
                return null;
            }
            public void UpdateCC( CustomClassAsArg c )
            {
                c.MyInfo = "updated";
            }
        }
        class Program
        {
            static void Main(string[] args)
            {
                ClassCaller.UpdateSourceCodeHelperFunctions(2);
                CallMe m = new CallMe();
                ClassCaller c = new ClassCaller(m);
                string r = "in string ";
                int arg = 1;
                String sx = "";
                object ox = c.DoCall("!MyStaticMethod", 23, ref sx);
                Console.WriteLine(sx);
                c.DoCall("Hello1", "hello world", 1);
                c.DoCall("Hello2", ref r);
                Console.WriteLine(r);
                c.DoCall("Hello2", ref arg);
                Console.WriteLine(arg.ToString());
                bool? rt = (bool?)c.DoCall("ThreeStateTest", 0);
                rt = (bool?)c.DoCall("ThreeStateTest", 1);
                rt = (bool?)c.DoCall("ThreeStateTest", 2);
                CustomClassAsArg ccarg = new CustomClassAsArg();
                c.DoCall("UpdateCC",ccarg);
            } //Main
        }
    }
