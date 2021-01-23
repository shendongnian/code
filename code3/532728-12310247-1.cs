    void Main() {
        for( double y=...
          for( double x=...
            int iterations = 0;
            MapPoint point = new MapPoint(x, y);
            while (iterations < 40 || point.Argument < 4.0)
            {
                point = point.Iterate();
                iterations++;
            }
            switch (iterations % 4)
            {
                //...
            }
        ...
    }
