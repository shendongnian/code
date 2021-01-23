    void Main()
    {
        var bugCount = 4;
        var window = System.Windows.Markup.XamlReader.Parse(someXaml) 
                as System.Windows.Window;
        window.Show();
        var canvas = window.FindName("canvas") 
                as System.Windows.Controls.Canvas;
        var bugs = new List<Bug>();
        var r = new Random();
        if(canvas != null)
        {
            for(int i=0; i < bugCount; i++)
            {
                var bug = new Bug();
                bug.Height = 50;
                bug.Width = 50;
                bug.Location = new System.Windows.Point(
                    r.Next(0, (int)canvas.Width), 
                    r.Next(0, (int)canvas.Height));
                canvas.Children.Add(bug);
                bugs.Add(bug);
            }
        }
        var dt = new System.Windows.Threading.DispatcherTimer();
        dt.Tick += (o,e) => MoveIt(bugs);
        dt.Interval = TimeSpan.FromMilliseconds(100);
        dt.Start();
        
    }
    
    public void MoveIt(List<Bug> bugs)
    {
        var r = new Random();
        foreach (var bug in bugs)
        {
            var dir = r.Next(0,4);
            switch (dir)
            {
                case 0: 
                    bug.Location = 
                        new System.Windows.Point(bug.Location.X + 1, bug.Location.Y); 
                    break;
                case 1: 
                    bug.Location = 
                        new System.Windows.Point(bug.Location.X - 1, bug.Location.Y); 
                    break;
                case 2: 
                    bug.Location = 
                        new System.Windows.Point(bug.Location.X, bug.Location.Y + 1); 
                    break;
                case 3: 
                    bug.Location = 
                        new System.Windows.Point(bug.Location.X, bug.Location.Y - 1); 
                    break;
            }
        }
    }
    
    public class Bug : System.Windows.Controls.UserControl
    {
        private static int _bugCounter = 0;
        public Bug()
        {
            this.BugId = _bugCounter++;
        }
        public int BugId {get; private set;}     
        private System.Windows.Point _location;
        public System.Windows.Point Location 
        {
            get { return _location; }
            set 
            { 
                _location = value; 
                System.Windows.Controls.Canvas.SetLeft(this, value.X);
                System.Windows.Controls.Canvas.SetTop(this, value.Y);
                InvalidateVisual();            
            }
        }
        
        protected override void OnRender(System.Windows.Media.DrawingContext ctx)
        {
            base.OnRender(ctx);
            Console.WriteLine("Yo, bug #{0} is rendering!", BugId);
            ctx.DrawRectangle(
                System.Windows.Media.Brushes.Red, 
                new System.Windows.Media.Pen(System.Windows.Media.Brushes.White, 1), 
                new System.Windows.Rect(Location, this.RenderSize));
            var formattedText = new System.Windows.Media.FormattedText(
                this.BugId.ToString(), 
                System.Globalization.CultureInfo.CurrentCulture, 
                System.Windows.FlowDirection.LeftToRight, 
                new System.Windows.Media.Typeface("Arial"), 
                12, 
                System.Windows.Media.Brushes.White);
            ctx.DrawText(
                formattedText, 
                new System.Windows.Point(Location.X + 10, Location.Y + 10));
        }
    }
    
    string someXaml =
    @"
    <Window
        xmlns=""http://schemas.microsoft.com/winfx/2006/xaml/presentation""
        xmlns:x=""http://schemas.microsoft.com/winfx/2006/xaml""
        Width=""320""
        Height=""240""
    >
        <Canvas 
            x:Name=""canvas""
            Width=""640""
            Height=""480""
            Background=""LightGray""
        />
    </Window>        
    ";
