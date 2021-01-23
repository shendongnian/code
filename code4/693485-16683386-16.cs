    public class StartGame
    {
    	public List<Ball> ballList { get; private set; }
        public StartGame()
        {
            this.ballList = new List<Ball>();
            InitializeComponent();
        }
    	
        private void StartGame_Load(object sender, EventArgs e)
        {
            //Add any balls you need here.
            ballList.add(new Ball(5, 10, 1, 1));
            ballList.add(new Ball(5, 10, 1, 1));
            ballList.add(new Ball(4, 12, 7, 5));
        }
        private void StartGame_Paint_1(object sender, PaintEventArgs e)
        {
            //This foreach loop will run through all the balls in ballList
      	    for(Ball ball : ballList)
    	    {
    	        e.Graphics.FillEllipse(Brushes.Blue, ball.positionX, ball.positionY, 10, 10);
                e.Graphics.DrawEllipse(Pens.Blue, ball.positionX, ball.positionY, 10, 10);
    	    }
        }
    }
