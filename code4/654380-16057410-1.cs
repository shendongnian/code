    var movingEvents = 
          Observable.FromEventPattern<MouseEventHandler, MouseEventArgs>(
            h => this.MouseMove += h, h => this.MouseMove -= h)
              .Select(x => x.EventArgs.Location)
              .Where(location =>
                   location.X >= viewPort.Location.X 
                      && location.X <= viewPort.Location.X + viewPort.Width
                      && location.Y >= viewPort.Location.Y 
                      && location.Y <= viewPort.Location.Y + viewPort.Height);
    movingEvents.Subscribe(update);
    public void update(Point p)
    {
        textBox1.Text = p.ToString();
    }
