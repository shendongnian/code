    public partial class MainPage : PhoneApplicationPage
        {
            DispatcherTimer gameTimer;
    
            string _START           = "START";
            string _FALLING         = "FALLING";
            string _LEFT            = "LEFT";
            string _RIGHT           = "RIGHT";
            string _CENTER          = "CENTER";
            string playerState      = "";
    
            int counter             = 0;
            int playerMoveTimeout   = 40;
            public int altitude { get; set; }
        
            // Constructor
            public MainPage()
            {
                InitializeComponent();
                buildGameArea();
                alt.Text = altitude.ToString();
                playerState = _START;
                gameTimer = new DispatcherTimer();
                gameTimer.Interval = new TimeSpan(3333);
                gameTimer.Start();
                gameTimer.Tick+=gameTimer_Tick;
               
            }
    
            void gameTimer_Tick(object sender, EventArgs e)
            {
    
                updatePlayer();
                updateGameElements();
            }
    
            public void buildGameArea()
            {
                Canvas.SetTop(cloud, -300);
            }
            public void reloadPlayer()
            {
                playerState = _START;
                playerMoveTimeout = 40;
                Canvas.SetTop(Player, 300);
                Canvas.SetLeft(Player, 200);
            }
            public void updatePlayer()
            {
                if (Canvas.GetTop(Player) > 800)
                {
                    reloadPlayer();
                }
    
    
                if (Canvas.GetLeft(Player) + Player.Width >= 480)
                {
                    playerState = _LEFT;
    
                }
                else if (Canvas.GetLeft(Player) <= 0)
                {
                    playerState = _RIGHT;
                }
    
                if (playerMoveTimeout <= 0)
                {
                    playerState = _FALLING;
                }
    
    
                if (playerState.Equals(_START))
                { }
                else if (playerState.Equals(_FALLING))
                {
                    Canvas.SetTop(Player, Canvas.GetTop(Player) + 30);
    
                }
                else if (playerState.Equals(_LEFT))
                {
                    Canvas.SetTop(Player, Canvas.GetTop(Player) - 40);
                    Canvas.SetLeft(Player, Canvas.GetLeft(Player) - 20);
                    playerMoveTimeout--;
                }
                else if (playerState.Equals(_RIGHT))
                {
                    Canvas.SetTop(Player, Canvas.GetTop(Player) - 40);
                    Canvas.SetLeft(Player, Canvas.GetLeft(Player) + 20);
                    playerMoveTimeout--;
    
                }
                else //CENTER
                {
                    Canvas.SetTop(Player, Canvas.GetTop(Player) - 40);
                    playerMoveTimeout--;
                }
                TapBox.Margin = Player.Margin;
            }
            public void updateGameElements()
            {
                alt.Text = altitude.ToString();
                 
                //This single conditional moves every single thing on the background canvas
                if (counter > 0)
                {
                    Canvas.SetTop(background, Canvas.GetTop(background) + 20);
                    counter -= 20;
                }
            }
    
            private void Rectangle_Tap_1(object sender, GestureEventArgs e)
            {
                System.Windows.Point point = e.GetPosition(Player);
                double Y = point.Y;
                double X = point.X;
                altitude += 100;
                if (X < 80)
                {
                    counter = 400;
                    playerMoveTimeout = 40;
                    playerState = _RIGHT;
    
                }
                else if (X > 120)
                {
                    counter = 400;
                    playerMoveTimeout = 40;
                    playerState = _LEFT;
    
                }
                else
                {
                    counter = 400;
                    playerMoveTimeout = 40;
                    playerState = _CENTER;
    
                }
            }
        }
