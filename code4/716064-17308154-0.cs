    public interface ITop
    {
    }
    public abstract class Top : ITop {
        public static ITop MakeMeOne(whatever x) {
            if(x == something) {
                return BottomA(x);
            }
            else {
                return BottomB(x);
            }
        }
    
        private class BottomA : Top {
            public BottomA(whatever x) {}
        }
    
        private class BottomB : Top {
            public BottomB(whatever x) {}
        }
    }
