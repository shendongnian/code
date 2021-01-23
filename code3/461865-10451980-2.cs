    const double Sin30 = 0.5;
    static readonly double Cos30 = Math.Cos(30*Math.PI/180); 
    for (int xLogical = 0; xLogical < NX; xLogical++) {
        for (int yLogical = 0; yLogical < NY; yLogical++) {
            double xGeo = GridDistance * xLogical * Cos30;
            double yGeo = GridDistance * (yLogical + xLogical * Sin30);
            ...
        }
    }
