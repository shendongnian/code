    int rMax = Color.Yellow.R;
    int rMin = Color.White.R;
    int bMax = Color.Yellow.B;
    int bMin = Color.White.B;
    int gMax = Color.Yellow.G;
    int gMin = Color.White.G;
    
    var colorList = new List<Color>();
    for(int i=0; i<size; i++)
    {
        var rAverage = rMin + (int)((rMax - rMin) * i / size);
        var bAverage = bMin + (int)((bMax - bMin) * i / size);
        var gAverage = gMin + (int)((gMax - gMin) * i / size);
       
        colorList.Add(Color.FromArgb(rAverage, gAverage, bAverage));
    }
