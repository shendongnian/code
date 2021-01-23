    class Transparency
    {
        public float Value = 0.0f;
    }
    
    class MainClass
    {
         Transparency transparency = new Transparency();
    
         // this List<Events> doesn't match class, but I'm sure this was just a sample of a larger problem
         List<Events> listOfEvents = new List<Events>();
    
         listOfEvents.Add(new FadeInEvent(transparency));
    }
    
    class FadeInEvent{
         Transparency transparency;
    
         public FadeInEvent(Transparency t) {
             transparency = t;
         }
    
         public void Update()  //Occurs every frame
         {
             transparency.Value += 0.01f;
         }
    }
