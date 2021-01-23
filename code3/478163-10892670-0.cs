    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Threading;
    
    public class DFS
    {
        static List<string> traversedList = new List<string>();
    
        static List<string> parentList = new List<string>();
        static Thread[] thread_array;
        //static BufferBlock<Object> buffer1 = new BufferBlock<Object>();
    
        public static void Main(string[] args)
        {
    
            int N = 100;
            int M = N * 4;
            int P = N * 16;
    
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
    
            List<string> global_list = new List<string>();
    
            StreamReader file = new StreamReader(args[args.Length - 2]);
    
    
            string text = file.ReadToEnd();
    
            string[] lines = text.Split('\n');
    
    
    
            string[][] array1 = new string[lines.Length][];
    
            for (int i = 0; i < lines.Length; i++)
            {
                lines[i] = lines[i].Trim();
                string[] words = lines[i].Split(' ');
    
                array1[i] = new string[words.Length];
    
                for (int j = 0; j < words.Length; j++)
                {
                    array1[i][j] = words[j];
                }
            }
    
            StreamWriter sr = new StreamWriter("E:\\Newtext1.txt");
    
            for (int i = 0; i < array1.Length; i++)
            {
                for (int j = 0; j < array1[i].Length; j++)
                {
                    if (j != 0)
                    {
                        sr.Write(array1[i][0] + ":" + array1[i][j]);
                        Console.WriteLine(array1[i][0] + ":" + array1[i][j]);
                        sr.Write(sr.NewLine);
                    }
                }
    
            }
            int start_no = Convert.ToInt32(args[args.Length - 1]);
            thread_array = new Thread[lines.Length];
            string first_message = "root";
            //buffer1.Post(first_message);
            //buffer1.Post(array1);
            //buffer1.Post(start_no);
            //buffer1.Post(1);
    
            for (int t = 1; t < lines.Length; t++)
            {
                Console.WriteLine("thread" + t);
                thread_array[t] = new Thread(new ThreadStart(thread_run));
                thread_array[t].Name = t.ToString();
                lock (thread_array[t])
                {
                    Console.WriteLine("working");
                    thread_array[t].Start();
                    thread_array[t].Join();
                }
    
            }
            stopwatch.Stop();
    
            Console.WriteLine(stopwatch.Elapsed);
            Console.ReadLine();
        }
    
        private static void dfs(string[][] array, int point)
        {
            for (int z = 1; z < array[point].Length; z++)
            {
                if ((!traversedList.Contains(array[point][z])))
                {
                    traversedList.Add(array[point][z]);
                    parentList.Add(point.ToString());
                    dfs(array, int.Parse(array[point][z]));
                }
    
            }
            return;
    
    
        }
    
        bool busy;
        private readonly object syncLock = new object();
    
        public static void thread_run()
        {
            try
            {
                string parent;
                string[][] array1;
                int point;
                int id;
                //parent = (string)buffer1.Receive();
                //array1 = (string[][])buffer1.Receive();
                //point = (int)buffer1.Receive();
                //id = (int)buffer1.Receive();
                object value;
                Console.WriteLine("times");
    
                if (Thread.CurrentThread.Name.Equals("Point.ToString()"))
                {
                    if (!traversedList.Contains("Point.ToString()"))
                    {
                        for (int x = 1; x < 99999; x++)
                        {
                            Console.WriteLine("times");
                            //if (buffer1.TryReceive(out value))
                            //{
                            //    array1 = (string[][])value;
                            //}
                            //if (buffer1.TryReceive(out value))
                            //{
                            //    id = (int)buffer1.Receive();
                            //}
                            //id++;
                            //buffer1.Post(parent);
                            //buffer1.Post(array1);
                            //buffer1.Post(x);
                            //buffer1.Post(id);
                            Console.WriteLine("times");
    
                            lock (syncLock)
                            {
                                while (busy)
                                {
                                    busy = false;
                                    Monitor.PulseAll(Thread.CurrentThread);
                                }
                                busy = true; // we've got it!
                            }
    
                            
                        }
    
                        //return;
                    }
                    else
                    {
                        //buffer1.Post(parent);
                        //buffer1.Post(array1);
                        //buffer1.Post(point);
                        //buffer1.Post(id);
                        lock (syncLock)
                        {
                            while (busy)
                            {
                                busy = false;
                                Monitor.PulseAll(Thread.CurrentThread);
                            }
                            busy = true; // we've got it!
                        }
                    }
                }
                else
                {
                    Console.WriteLine("working 2");
                    lock (syncLock)
                    {
                        while (busy)
                        {
                            Monitor.Wait(Thread.CurrentThread);
                        }
                        busy = true; // we've got it!
                    }
                    
                }
                //Console.WriteLine(parent);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
    
        }
    
    }
