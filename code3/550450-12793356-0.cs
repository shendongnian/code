    class MainClass
    {
        float transparency = 0.0f;
        public float Transparency
        {
            get { return transparency;}
            set { transparency = value;}
        }
        List<Events> listOfEvents;
        listOfEvents.Add(new FadeInEvent(ref float transparency));
    }
    class FadeInEvent
    {
        MainClass mainClass;
         public FadeInEvent(MainClass mainClass) 
         {
             this.mainClass = mainClass;
         }
         public void Update()  //Occurs every frame
         {
             mainClass.Transparency += 0.01f;
         }
    }
