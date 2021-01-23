    public Form1(){
     InitializeComponent();
     Timer t = new Timer();
     t.Interval = 1;
     var offsetTimeStamp = new System.TimeSpan(0,0,0).Add(TimeSpan.FromSeconds((double)jd.ActualTime));
     int i = 0;
     t.Tick += (s,e) => {
       if(i++ == offsetTimeStamp.TotalMiliseconds) {
         watch.Start();
         t.Stop();
       }
     }; 
     //Try running your Timer 
     t.Start();   
    }
