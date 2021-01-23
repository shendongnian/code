    public class StartGame
    {
    	private List<Ball> ballList = new ArrayList<Ball>();
        public StartGame()
        {
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
            //This foreach loop will modify all the balls in ballList
      	    for(Ball ball : ballList)
    	    {
    	        e.Graphics.FillEllipse(Brushes.Blue, ball.getPositionX(), ball.getPositionY(), 10, 10);
    	    }
        }
    }
