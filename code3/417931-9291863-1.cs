    class something
        {
            public somethingnested sn;
    
            public class somethingnested
            {
                public somethingtotalynested stn;
                public class somethingtotalynested
                {
                    public string str;
                }
    
                public somethingnested()
                {
                    this.stn = new somethingtotalynested();
                }
            }
    
            public something()
            {
                this.sn = new somethingnested();
            }
        }
