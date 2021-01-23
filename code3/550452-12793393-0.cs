    class FadeInEvent
    {
         public event Action<float> TransparencyChanged = delegate { };
    
         public float Transparency
         {
             get { return _Transparency; }
             private set
             {
                  _Transparency = value;
                 TransparencyChanged(value);
             }
         }
         float _Transparency;
    
         public FadeInEvent(float t) {
             _Transparency = t;
         }
    
         public void Update()  //Occurs every frame
         {
             Transparency += 0.01f;
         }
    }
