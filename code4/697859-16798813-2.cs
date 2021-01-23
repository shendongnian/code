    public static class ComplexExtensions {
        public static Complex[] NthRoot(this Complex complex, int n) {
            Contract.Requires(n > 0);
            var phase = complex.Phase;
            var magnitude = complex.Magnitude;
            var nthRootOfMagnitude = Math.Pow(magnitude, 1.0 / n);
            return
                Enumerable.Range(0, n)
                          .Select(k => Complex.FromPolarCoordinates(
                              nthRootOfMagnitude,
                              phase / n + k * 2 * Math.PI / n)
                          )
                          .ToArray();
        }
    }
