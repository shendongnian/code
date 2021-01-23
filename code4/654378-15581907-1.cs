    class BallUpdate
    {
        public BallUpdate(){}
    
        public void ballMotion(Ball x)
        {
            while(true)
            {
                x.moveBall();
                Thread.Sleep(10000);
            }   
        }
    }
