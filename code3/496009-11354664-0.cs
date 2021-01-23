    public class QSquare : QShape, IHasLength {
        public int sideLength;
        public QSquare(int theSideLength, int theX, int theY, string theColour) {
            this.sideLength = theSideLength;
            this.x = theX;
            this.y = theY;
            this.colour = theColour;
        }
        public int Length { get { return sideLength; } }
    }
    public class QCircle : QShape, IHasLength {
        public int radius;
        public QSquare(int theSideLength, int theX, int theY, string theColour) {
            this.sideLength = theSideLength;
            this.x = theX;
            this.y = theY;
            this.colour = theColour;
        }
        public int Length { get { return radius; } }
    }
