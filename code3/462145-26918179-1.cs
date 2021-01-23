       void wait (double x){
            DateTime t = DateTime.Now;
            DateTime tf = DateTime.Now.AddSeconds(x);
            while (t < tf)
            {
                t = DateTime.Now;
            }
        }
