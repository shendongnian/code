    Ball ball;  //In the class scope
    
    protected override void Initialize()
    {
        ball = new Ball(gPaddle);
        base.Initialize();
    }
