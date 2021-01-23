    var firstColor = Color.Red;
    var secondColor = Color.Green;
    int rMin = firstColor.R;
    int rMax = secondColor.R;
    int bMin = firstColor.B;
    int bMax = secondColor.B;
    int gMin = firstColor.G;
    int gMax = secondColor.G;
    int size = 10;
    for (int i = 0; i < size; i++)
    {
        var rAverage = rMin + (int)((rMax - rMin) * i / size);
        var gAverage = gMin + (int)((gMax - gMin) * i / size);
        var bAverage = bMin + (int)((bMax - bMin) * i / size);
        var currentColor = Color.FromArgb(rAverage, gAverage, bAverage);
        // TODO: use the currentColor
    }
