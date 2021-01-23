    Vector2 Origin = new Vector2(260, 90);
    Vector2 Target = new Vector2(660, 180);
    Vector2 Forward = Vector2.Normalize(Target-Source);
    float Speed = 100; // Pixels per second
    float Duration = (Target - Origin).Length() / Speed;
    float Time = 0;
    public void Update(float ElapsedSecondsPerFrame)
    {
       if (Time<Duration)
       {
          Time+=Duration;
          if (Time > Duration) {
              Time = Duration;
              Origin = Target;
          }
          else Origin += Forward * Speed * ElapsedSecondsPerFrame;
       } 
    }
    
    public void Draw()
    {
        rect = new Rectangle((int) Origin.X, (int) Origin.Y, 80, 120);
        sb.Draw(point, rect, Color.Red);   
    }
   
