    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    
    namespace Physics_16783733
    {
        class Program
        {
            static void Main(string[] args)
            {
                MyClass c = new MyClass();
            }
        }
    
        public class MyClass
        {
            public Settings config = new Settings();
    
            public float displacement = 0f;
    
            public Stopwatch timer = new Stopwatch();
            public float timeElapsed; //in Seconds
    
            public Thread thread;
    
            static ManualResetEvent control;
    
            public MyClass()
            {
                control = new ManualResetEvent(false);
                //New thread (Drawing)
                thread = new Thread(new ThreadStart(Drawing));
                thread.IsBackground = true;
                thread.Start();
    
                control.WaitOne();
            }
    
            public void Drawing()
            {
                try
                {
                    while (true)
                    {
                        if (config.objectPos.Y < config.sizeBitmap.Height)
                        {
                            timer.Start();
                        }
                        else
                        {
                            timer.Stop();
                            control.Set();
                        }
                        //Bitmap screen = new Bitmap(this.pboxScreen.Width, this.pboxScreen.Height);
                        SendScreen();
                    }
                }
                catch (ThreadAbortException tae)
                {
                    Console.WriteLine(tae.Message);
                }
            }
    
            private void SendScreen()
            {
                timeElapsed = timer.ElapsedMilliseconds / 1000f; //Converting Milliseconds to Seconds
    
                if (config.objectPos.Y < config.sizeBitmap.Height) //Check if object isn't in the ground
                {
                    displacement -= config.objectPos.Y;
    
                    //formula used is in http://www.physicsclassroom.com/Class/1DKin/U1L6c.cfm
                    config.objectPos.Y = 0 //initial velocity
                        + 0.5f * config.acceleration * timeElapsed * timeElapsed;
                    displacement += config.objectPos.Y;
                }
    
                //Update txtbox (textbox)
                Console.WriteLine("Object position Y: " + config.objectPos.Y.ToString());
                Console.WriteLine("Time elapsed     : " + timeElapsed.ToString()); //using the data from http://www.physicsclassroom.com/Class/1DKin/U1L6c.cfm, time elapsed should be 1.32 seconds
                Console.WriteLine("Displacement     : " + displacement.ToString());
            }
        }
    
        public class Settings
        {
            //I used data from http://www.physicsclassroom.com/Class/1DKin/U1L6c.cfm
            //where the given is:
    
            //vi = 0.0 m/s
            //d = -8.52 m
            //a = - 9.8 m/s2
    
            public Size sizeBitmap; //height of the place where the object will start free falling
            public PointF objectPos; //Initial Position
            public float acceleration;
    
            public Settings()
            {
                sizeBitmap.Height = 8.52;
                objectPos.Y = 0;
                acceleration = 9.8f;
            }
    
        }
    
        public struct PointF
        {
            public float Y { get; set; }
        }
    
        public struct Size
        {
            public double Height { get; set; }
        }
    }
