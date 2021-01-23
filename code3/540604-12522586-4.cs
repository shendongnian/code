    namespace Your.App
    {
    //correct implementation of the Strategy Pattern
        public class MyWorkContext
        {
            WorkClass Worker {get; set;}
            public MyWorkContext()
            {
                Worker = new WorkClass();
            }
            public void SendMyData()
            {
                if(someConditionIsMet)
                    Worker.UseAsync = true;
                else
                    Worker.UseAsync = false;
                Worker.Send();
            }
        }
    }
