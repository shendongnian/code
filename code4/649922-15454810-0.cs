    public class Service1 : System.Web.Services.WebService
    {
        static Queue myQueue = new Queue();
    
        [WebMethod]
        public void push(int item)
        {
            lock(myQueue)
            {
                myQueue.Enqueue(item);
            }
        }
    
        [WebMethod]
        public int pop()
        {
            lock(myQueue)
            {
                if (myQueue.Count != 0)
                {
                    return (int)myQueue.Dequeue();
                }
    
                return -1;
            }
        }
    }
