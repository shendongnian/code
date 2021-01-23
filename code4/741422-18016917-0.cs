    public class Digit {
        protected int value;
        protected List<Segment> segmentList;
        public Digit (int value, Segment... segments) {
            this.value = value;
            this.segmentList = Arrays.asList( segments);
        }
        
        public void draw (int x, int y) {
            for (Segment seg : segmentList) {
                seg.draw( x, y);
            }
        }
    }
    public enum Segment {
        TOP (0, 0, 1, 0),    // x0,y0, x1,y1
        LT  (0, 0, 0, 1),
        RT  (1, 0, 1, 1),
        MID (0, 1, 1, 1),
        LB  (0, 1, 0, 2),
        RB  (1, 1, 1, 2),
        BOT (0, 2, 1, 2);
        private Segment (int x0, int y0, int x1, int y1) {
             // assign x0,y0 & x1,y1 to fields.
        }
        public draw (int xofs, int yofs) {
             // draw..
        }
    }
    // setup the Digits somewhere..  then:
    public void drawScore (int number, int xofs, int yofs) {
        int remain = number;
        int digitI = 0;
        while (remain > 0 || digitI == 0) {
            int digit = (remain % 10);
            remain /= 10;
            // draw the digit.
            //
            int xpos = digit * DIGIT_WIDTH;
            digits[digit].draw( xpos, SCORE_YPOS);
        }
    }
