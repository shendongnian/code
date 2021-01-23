    //Class used to store e.getPosition(UIElement).X/Y
    public class mouseInformation
        {
            public int x { get; set; }
            public int y { get; set; }
            
            public mouseInformation(int x, int y, String functionName)
            {
                this.x = x;
                this.y = y;              
            }
        }
    
        private readonly Queue<mouseInformation> queueOfEvent = new Queue<mouseInformation>();
        //MouseMove listener
        private void wpCanvas_MouseDragged(object sender, System.Windows.Input.MouseEventArgs e)
        {
            //Instead of "wpCanvas" put the name of your UIElement (here your canvas name)
            mouseInformation mouseDragged = new mouseInformation((int)e.GetPosition(wpCanvas).X, (int)e.GetPosition(wpCanvas).Y);
           
            EnqueueMouseEvent(mouseDragged);
            
        }
        //Allow you to add a MouseInformation object in your Queue
        public void EnqueueMouseEvent(mouseInformation mi)
        {
      
            lock (queueOfEvent)
            {
                queueOfEvent.Enqueue(mi);
                Monitor.PulseAll(queueOfEvent);
            }
        }
        //Logic that your consumer thread will do
        void Consume()
        {
            while (true)
            {
                mouseInformation MI;
                lock (queueOfEvent)
                {          
                    while (queueOfEvent.Count == 0) Monitor.Wait(queueOfEvent);
                    MI = queueOfEvent.Dequeue();  
                }
 
                    // DO YOUR LOGIC HERE
                    // i.e  DoSomething(MI.x, MI.y)               
            }
        }
        
