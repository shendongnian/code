    public class DataLoader
    {
        private Sub mySub;
    
        public void Process1()
        {
            mySub = new Sub();
        }
    
        public void Process2()
        {
            if(mySub == null) 
                throw new InvalidOperationException("Called Process2 before Process1!");            
            // use mySub here
        }
    }
