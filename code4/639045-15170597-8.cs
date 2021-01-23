    //Listing all the parameters
    public partial class Form1 : Form
    {
        #region Declaring Parameters
        enum Direction
        {
            Left, Right, Up, Down
        }
        private int _x;
        private int _y;
        private int _k;
        private Direction _objDirection;
        Random rand = new Random();
        private int _boardWidth;
        private int _boardHeight;
        private int[,] level;
        #endregion
        //Giving values to parameters
        public Form1()
        {
            InitializeComponent();
            #region Initialial values
            _k = 1;
            _boardWidth = 6;
            _boardHeight = 6;
            _x = rand.Next(0, _boardWidth - 1);
            _y = rand.Next(0, _boardHeight - 1);
            _objDirection = Direction.Left;
            //Array that works as a board or platform which we used to distinguish tiles
            level = new int[_boardWidth, _boardHeight];
            #endregion
        }
        //Paint is used for drawing purposes only
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            /*
                   int[,] level = {
                                   { 0, 0, 0, 0, 0 ,0 },
                                   { 0, 0, 0, 0, 0 ,0 },
                                   { 0, 0, 0, 0, 0 ,0 },
                                   { 0, 0, 0, 0, 0 ,0 },
                                   { 0, 0, 0, 0, 0 ,0 },
                                   { 0, 0, 0, 0, 0 ,0 },
                               };
            */
            #region Looping through tiles
            //Initializing first randomly filled tile
            level[_x, _y] = _k;
            for (int y = 0; y < _boardHeight; y++)
            {
                for (int x = 0; x < _boardWidth; x++)
                {
                    //Empty Tile
                    if (level[x, y] == 0)
                    {
                        // Create pen.
                        Pen redPen = new Pen(Color.Red, 1);
                        // Create rectangle.
                        Rectangle redRect = new Rectangle(x * 50, y * 50, 50, 50);
                        // Draw rectangle to screen.
                        e.Graphics.DrawRectangle(redPen, redRect);
                    }
                    //Occupied Tile
                    if (level[x, y] == 1)
                    {
                        // Create solid brush.
                        SolidBrush blueBrush = new SolidBrush(Color.Blue);
                        // Create rectangle.
                        Rectangle rect = new Rectangle(x * 50, y * 50, 50, 50);
                        // Fill rectangle to screen.
                        e.Graphics.FillRectangle(blueBrush, rect);
                    }
                }
            }
            #endregion
        }
        //Responsible for movements
        private void tmrMov_Tick(object sender, EventArgs e)
        {
            #region Timer function
            // instead, keep track temporarily
            // what they were
            var oldX = _x;
            var oldY = _y;
            // let's figure these out ahead of time
            var spaceOnLeft = _x > 0;
            var spaceOnRight = _x < _boardWidth - 1;
            var spaceOnTop = _y > 0;
            var spaceOnBottom = _y < _boardHeight - 1;
            // switch is a bit like the if/else construct you had
            switch (_objDirection)
            {
                case Direction.Up:
                    // this means: if(spaceOnTop) y = y-1 else y = height-1
                    _y = spaceOnTop ? _y - 1 : _boardHeight - 1;
                    break;
                case Direction.Down:
                    _y = spaceOnBottom ? _y + 1 : 0;
                    break;
                case Direction.Left:
                    _x = spaceOnLeft ? _x - 1 : _boardWidth - 1;
                    break;
                case Direction.Right:
                    _x = spaceOnRight ? _x + 1 : 0;
                    break;
            }
            // now we'll use the old values to clear...
            level[oldX, oldY] = 0;
            // then set the new value
            level[_x, _y] = _k;
            #endregion
            panel1.Refresh();
        }
        //Event Handler (W,A,S,D) is used for movements
        private void Form1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            #region Controls
            // same deal here, but with keys
            switch (e.KeyCode)
            {
                case Keys.Up:
                    e.IsInputKey = true;
                    _objDirection = Direction.Up;
                    break;
                case Keys.Down:
                    e.IsInputKey = true;
                    _objDirection = Direction.Down;
                    break;
                case Keys.Left:
                    e.IsInputKey = true;
                    _objDirection = Direction.Left;
                    break;
                case Keys.Right:
                    e.IsInputKey = true;
                    _objDirection = Direction.Right;
                    break;
            }
            #endregion
        }
    }
