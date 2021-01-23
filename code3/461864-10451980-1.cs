    for (int xLogical = 0; xLogical < NX; xLogical++) {
        for (int yLogical = 0; yLogical < NY; yLogical++) {
            double xGeo = GridSize * xLogical * Math.Cos(30*Math.PI/180);
            double yGeo = GridSize * (yLogical + xLogical * 0.5;
            // With   Math.Sin(30*Math.PI/180) = 0.5
            ...
        }
    }
