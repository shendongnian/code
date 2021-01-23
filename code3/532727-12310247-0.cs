    public struct MapPoint
    {
        public double realCoord, imagCoord;
        public double realConst, imagConst;
        public MapPoint(double realConst, double imagConst)
            : this(realConst, imagConst, realConst, imagConst) { }
        public MapPoint(double realCoord, double imagCoord, double realConst, double imagConst)
        {
            this.realCoord = realCoord;
            this.imagCoord = imagCoord;
            this.realConst = realConst;
            this.imagConst = imagConst;
        }
        public double Argument // calculated property
        {
            get { return realCoord * realCoord + imagCoord * imagCoord; }
        }
        public MapPoint Iterate()
        {
            // Do the z = z^2+c thing
            return new MapPoint(
                realCoord * realCoord - imagCoord * imagCoord + realConst,
                2 * realCoord * imagCoord + realConst,
                realConst, imagConst);
        }
    }
