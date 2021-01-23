    using System;
            using System.Collections.Generic;
            using System.Linq;
            using System.Text;
            using System.Threading.Tasks;
            using System.Threading;
            
            namespace testLock
            {
                class Program
                {
                    public static void Main()
                    {
                        // Start a thread that calls a parameterized static method.
                        for(int i = 0; i< 10;i++)
                        {
                            Thread newThread = new Thread(DoWork);
                            newThread.Start(i);
                        }
            
                        Console.ReadLine();
                    }
            
                    static object gObject= new object();
                    public static void DoWork(object data)
                    {
                        int len = (int)data % 3;
                        object tmp = new object();
                        Console.WriteLine("to lock...... Data='{0}'  sleepTime:{1}", data, len);
                        lock (tmp)//tmp won't work, change tmp to gObject to see different output, which is good locking case)
                        {
                            Console.WriteLine("in lock...... Data='{0}'  sleepTime:{1}", data, len);
                            
                            Thread.Sleep(  len* 1000);
                            Console.WriteLine("Static thread procedure. Data='{0}'  sleepTime:{1}", data, len);
                        }
                    }
            
                }
            }
        
        **Lock temp variable,will output:**
        to lock...... Data='1'  sleepTime:1
        in lock...... Data='1'  sleepTime:1
        to lock...... Data='2'  sleepTime:2
        in lock...... Data='2'  sleepTime:2
        to lock...... Data='0'  sleepTime:0
        in lock...... Data='0'  sleepTime:0
        Static thread procedure. Data='0'  sleepTime:0
        to lock...... Data='3'  sleepTime:0
        in lock...... Data='3'  sleepTime:0
        Static thread procedure. Data='3'  sleepTime:0
        to lock...... Data='4'  sleepTime:1
        in lock...... Data='4'  sleepTime:1
        to lock...... Data='5'  sleepTime:2
        in lock...... Data='5'  sleepTime:2
        to lock...... Data='6'  sleepTime:0
        in lock...... Data='6'  sleepTime:0
        Static thread procedure. Data='6'  sleepTime:0
        to lock...... Data='7'  sleepTime:1
        in lock...... Data='7'  sleepTime:1
        to lock...... Data='8'  sleepTime:2
        in lock...... Data='8'  sleepTime:2
        to lock...... Data='9'  sleepTime:0
        in lock...... Data='9'  sleepTime:0
        Static thread procedure. Data='9'  sleepTime:0
        Static thread procedure. Data='1'  sleepTime:1
        Static thread procedure. Data='4'  sleepTime:1
        Static thread procedure. Data='7'  sleepTime:1
        Static thread procedure. Data='2'  sleepTime:2
        Static thread procedure. Data='5'  sleepTime:2
        Static thread procedure. Data='8'  sleepTime:2
        
        **Then lock gObject, will print:**
        to lock...... Data='0'  sleepTime:0
        in lock...... Data='0'  sleepTime:0
        to lock...... Data='1'  sleepTime:1
        to lock...... Data='2'  sleepTime:2
        Static thread procedure. Data='0'  sleepTime:0
        in lock...... Data='1'  sleepTime:1
        to lock...... Data='3'  sleepTime:0
        to lock...... Data='4'  sleepTime:1
        to lock...... Data='5'  sleepTime:2
        to lock...... Data='6'  sleepTime:0
        to lock...... Data='7'  sleepTime:1
        to lock...... Data='8'  sleepTime:2
        to lock...... Data='9'  sleepTime:0
        Static thread procedure. Data='1'  sleepTime:1
        in lock...... Data='5'  sleepTime:2
        Static thread procedure. Data='5'  sleepTime:2
        in lock...... Data='9'  sleepTime:0
        Static thread procedure. Data='9'  sleepTime:0
        in lock...... Data='2'  sleepTime:2
        Static thread procedure. Data='2'  sleepTime:2
        in lock...... Data='8'  sleepTime:2
        Static thread procedure. Data='8'  sleepTime:2
        in lock...... Data='7'  sleepTime:1
        Static thread procedure. Data='7'  sleepTime:1
        in lock...... Data='4'  sleepTime:1
        Static thread procedure. Data='4'  sleepTime:1
        in lock...... Data='3'  sleepTime:0
        Static thread procedure. Data='3'  sleepTime:0
        in lock...... Data='6'  sleepTime:0
        Static thread procedure. Data='6'  sleepTime:0
