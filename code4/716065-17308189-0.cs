    public abstract class ITop {
        public static ITop MakeMeOne(whatever x) {
            if(x == something) {
                return BottomA(x);
            }
            else {
                return BottomB(x);
            }
        }
    
        private class BottomA : ITop {
            public BottomA(whatever x) {}
        }
    
        private class BottomB : ITop {
            public BottomB(whatever x) {}
        }
    }
 
