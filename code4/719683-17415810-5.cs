    using System;
    using System.Linq;
    using System.Windows;
    using System.Windows.Navigation;
    using Microsoft.Phone.Controls;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input.Touch;
    using Point = Microsoft.Xna.Framework.Point;
    
    namespace SlXnaApp1
    {
        public partial class GamePage : PhoneApplicationPage
        {
            private readonly GameTimer _timer;
            private int[] _levels;
            private Point _player;
            private Texture2D _t1;
            private Texture2D _t2;
            private Texture2D _t3;
            private Texture2D[] _textures;
            private ContentManager _contentManager;
            private SpriteBatch _spriteBatch;
    
            public GamePage()
            {
                InitializeComponent();
    
                // Get the content manager from the application
                _contentManager = (Application.Current as App).Content;
    
                // Create a timer for this page
                _timer = new GameTimer();
                _timer.UpdateInterval = TimeSpan.FromTicks(333333);
                _timer.Update += OnUpdate;
                _timer.Draw += OnDraw;
            }
    
            protected override void OnNavigatedTo(NavigationEventArgs e)
            {
                // Set the sharing mode of the graphics device to turn on XNA rendering
                var graphicsDevice = SharedGraphicsDeviceManager.Current.GraphicsDevice;
                graphicsDevice.SetSharingMode(true);
    
                // Create a new SpriteBatch, which can be used to draw textures.
                _spriteBatch = new SpriteBatch(graphicsDevice);
    
                // TODO: use this.content to load your game content here
                _t1 = new Texture2D(graphicsDevice, 32, 32);
                _t1.SetData(Enumerable.Repeat(Color.Red, 32*32).ToArray());
                _t2 = new Texture2D(graphicsDevice, 32, 32);
                _t2.SetData(Enumerable.Repeat(Color.Green, 32*32).ToArray());
                _t3 = new Texture2D(graphicsDevice, 32, 32);
                _t3.SetData(Enumerable.Repeat(Color.Blue, 32*32).ToArray());
                _textures = new[] {_t1, _t2, _t3};
                _levels = new int[4*4]
                    {
                        2, 0, 0, 0,
                        0, 0, 1, 0,
                        1, 1, 1, 0,
                        0, 0, 0, 1,
                    };
                _player = new Point();
    
                TouchPanel.EnabledGestures = GestureType.Flick;
                // Start the timer
                _timer.Start();
    
                base.OnNavigatedTo(e);
            }
    
            protected override void OnNavigatedFrom(NavigationEventArgs e)
            {
                // Stop the timer
                _timer.Stop();
    
                // Set the sharing mode of the graphics device to turn off XNA rendering
                SharedGraphicsDeviceManager.Current.GraphicsDevice.SetSharingMode(false);
    
                base.OnNavigatedFrom(e);
            }
    
            /// <summary>
            ///     Allows the page to run logic such as updating the world,
            ///     checking for collisions, gathering input, and playing audio.
            /// </summary>
            private void OnUpdate(object sender, GameTimerEventArgs e)
            {
                Vector2 vector = new Vector2();
                while (TouchPanel.IsGestureAvailable)
                {
                    var gestureSample = TouchPanel.ReadGesture();
                    var vector2 = gestureSample.Delta;
                    vector2.Normalize();
                    vector = new Vector2((float) Math.Round(vector2.X), (float) Math.Round(vector2.Y));
                }
    
                Direction direction = new Direction();
                if (vector.X > 0) direction = Direction.Right;
                else if (vector.X < 0) direction = Direction.Left;
                else if (vector.Y < 0) direction = Direction.Up;
                else if (vector.Y > 0) direction = Direction.Down;
    
                Point newPos = new Point();
                switch (direction)
                {
                    case Direction.None:
                        return;
                    case Direction.Up:
                        if (GetTile(_player.X, _player.Y - 1) == 0)
                            newPos = new Point(_player.X, _player.Y - 1);
                        else return;
                        break;
                    case Direction.Down:
                        if (GetTile(_player.X, _player.Y + 1) == 0)
                            newPos = new Point(_player.X, _player.Y + 1);
                        else return;
                        break;
                    case Direction.Left:
                        if (GetTile(_player.X - 1, _player.Y) == 0)
                            newPos = new Point(_player.X - 1, _player.Y);
                        else return;
                        break;
                    case Direction.Right:
                        if (GetTile(_player.X + 1, _player.Y) == 0)
                            newPos = new Point(_player.X + 1, _player.Y);
                        else return;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
    
                SetTile(_player.X, _player.Y, 0);
                SetTile(newPos.X, newPos.Y, 2);
                _player = newPos;
            }
    
            private int GetTile(int x, int y)
            {
                return _levels[y*4 + x];
            }
    
            private void SetTile(int x, int y, int value)
            {
                _levels[y*4 + x] = value;
            }
    
            /// <summary>
            ///     Allows the page to draw itself.
            /// </summary>
            private void OnDraw(object sender, GameTimerEventArgs e)
            {
                SharedGraphicsDeviceManager.Current.GraphicsDevice.Clear(Color.CornflowerBlue);
                _spriteBatch.Begin();
                for (int i = 0; i < _levels.Length; i++)
                {
                    var tile = _levels[i];
                    Point point = new Point(i%4, i/4);
                    var texture2D = _textures[tile];
                    _spriteBatch.Draw(texture2D, Vector2.Multiply(new Vector2(point.X, point.Y), 32), Color.White);
                }
                _spriteBatch.End();
            }
    
            private enum Direction
            {
                None,
                Up,
                Down,
                Left,
                Right
            }
        }
    }
