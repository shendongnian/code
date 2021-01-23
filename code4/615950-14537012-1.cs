I'd suggest to build a class with an appropriate interface though, as building Funcs on the fly is pretty complicated (see [here][3] for an example). You could do something like:
    public class CosineInterpolation {
        public CosineInterpolation(double[] x, double[] y) { ... }
        public double Interpolate(double x) { ... }
    }
