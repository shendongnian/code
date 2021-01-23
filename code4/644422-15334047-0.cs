    static void Main(string[] args)
    {
        System.Windows.Forms.Form f = new System.Windows.Forms.Form();
        f.ClientSize = new System.Drawing.Size(800, 600);
        f.TransparencyKey = f.BackColor;
        ((Action)(() => System.Windows.Forms.Application.Run(f))).BeginInvoke(
                                                                   null, null);
    
        using (Game1 game = new Game1())
        {
            f.ResizeEnd += new EventHandler(game.f_LocationChanged);
            game.Run();
        }
    }
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        public static Rectangle windowRect;
        /* ... */
        protected override void Update(GameTime gameTime)
        {
            if (windowRect.X != this.Window.ClientBounds.X ||
                windowRect.Y != this.Window.ClientBounds.Y ||
                windowRect.Width != this.Window.ClientBounds.Width ||
                windowRect.Height != this.Window.ClientBounds.Height)
            {
                 // this method sets the game window size, but not location
                InitGraphicsMode(windowRect.Width, windowRect.Height,
                  this.graphics.IsFullScreen);
                var win = System.Windows.Forms.Control.FromHandle(
                 this.Window.Handle) as
                  System.Windows.Forms.Form;
                win.SetBounds(windowRect.X,
                              windowRect.Y,
                              windowRect.Width,
                              windowRect.Height);
                win.Activate();
            }
        }
        public void f_LocationChanged(object sender, EventArgs e)
        {
            var FakeWindow = sender as System.Windows.Forms.Form;
            
            var drawClientArea = FakeWindow.RectangleToScreen(
                                   FakeWindow.ClientRectangle);
            windowRect = new Rectangle(
                       drawClientArea.X,
                       drawClientArea.Y,
                       drawClientArea.Width,
                       drawClientArea.Height);
        }
    }
