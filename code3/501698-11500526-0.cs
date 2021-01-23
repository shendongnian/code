                //Anywhere You like
                // Idea of timer is more better. But If you want to use threads. Then Follow this
                // Let me assume that You want to do it right from the start of program
                // You can write in body of function (event in fact) named Form1_Load as
                // Your actual code is just within while loop other code only to guide
                // to guide if you don't know the use of threads in C#
                // If any problem let me know at eagle.ciit@gmail.com
    bool button2Clicked = false;
    private void Form1_Load(object sender, EventArgs e)
    {    
                // A good Way to call Thread
                System.Threading.Thread t1 = new System.Threading.Thread(delegate()
                {
                    while (!button2Clicked)
                    {
                        // Do Any Stuff;
                        System.Threading.Thread.Sleep(60000);//60000 Milli Seconds=1M                    
                    }
                });
                t1.IsBackground = true;
                // With above statement Thread Will automatically be Aborted on Application Exit         
                t1.Start();
    }
