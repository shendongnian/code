    private void Element _MouseDown(object sender, MouseButtonEventArgs e)
    {
        Point position = e.GetPosition(myCanvas);
        this.myElement.RenderTransform =
                new TranslateTransform(position.X - myElement/ 2.0,
                                        position.Y - myElement/ 2.0);
            this.myCanvas.MouseMove += myCanvas_MouseMove;
            this.myCanvas.MouseUp += myCanvas_MouseUp;
    }
    private void myCanvas_MouseMove(object sender, MouseEventArgs e)
    {
        Point position = e.GetPosition(this.myCanvas);
        ((TranslateTransform)(this.myElement.RenderTransform)).X = position.X - myElement/ 2.0;
            //
        ((TranslateTransform)(this.myElement.RenderTransform)).Y = position.Y - myElement/ 2.0;
    }
     private void myCanvas_MouseUp(object sender, MouseEventArgs e)
    {
         this.myCanvas.MouseMove -= myCanvas_MouseMove;
         this.myCanvas.MouseUp -= myCanvas_MouseUp;
    }
