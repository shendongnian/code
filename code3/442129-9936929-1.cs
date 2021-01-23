    private void AnimationWorkerOnDoWork( object sender, DoWorkEventArgs doWorkEventArgs ) {
      var p = (Point) doWorkEventArgs.Argument;
      const int numPoints = 1000;
      var r = 100;
      var a = 0.0;
      var pc = new PointCollection();
      for( var i = 0; i <= numPoints; i++ ) {
        var pt = new Point();
        pt.X = p.X + r * Math.Cos( a );
        pt.Y = p.Y + r * Math.Sin( a );
        double rr = 0.5 * r;
        double aa = -0.8 * a;
        Point pnt = new Point();
        pnt.X = pt.X + rr * Math.Cos( aa );
        pnt.Y = pt.Y + rr * Math.Sin( aa );
        a += 0.5;
        _animationWorker.ReportProgress( 0, pnt );
        Thread.Sleep( 10 );
        if( _animationWorker.CancellationPending ) break;
      }
    }
