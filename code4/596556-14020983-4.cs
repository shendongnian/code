        Storyboard sb = new Storyboard();
        DoubleAnimationUsingPath ani_2 = new DoubleAnimationUsingPath();
        ani_2.Duration = new Duration(new TimeSpan(0, 0, 2));
        PathGeometry pg = new PathGeometry();
        pg.Figures.Add(new PathFigure());
        ani_2.PathGeometry.AddGeometry(pg);
