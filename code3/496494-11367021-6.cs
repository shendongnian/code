    public static class PolyAnalyzerFactory {
        public static Analyzer Create( params double[] coefs ) {
            return new Analyzer(
                x =>
                {
                    double sum = 0;
                    for ( int i = 0 ; i < coefs.Length ; i++ ) {
                        sum += coefs[i] * Math.Pow(x,coefs.Length-1-i);
                    }
                    return sum;
                });
        }
    }
