    using System;
    using System.Collections.Generic;
    using System.Linq;
    /// <summary>
    /// Linear Interpolation using the least squares method
    /// <remarks>http://mathworld.wolfram.com/LeastSquaresFitting.html</remarks> 
    /// </summary>
    public class LinearLeastSquaresInterpolation
    {
        /// <summary>
        /// point list constructor
        /// </summary>
        /// <param name="points">points list</param>
        public LinearLeastSquaresInterpolation(IEnumerable<Point> points)
        {
            Points = points;
        }
        /// <summary>
        /// abscissae/ordinates constructor
        /// </summary>
        /// <param name="x">abscissae</param>
        /// <param name="y">ordinates</param>
        public LinearLeastSquaresInterpolation(IEnumerable<float> x, IEnumerable<float> y)
        {
            if (x.Empty() || y.Empty())
                throw new ArgumentNullException("null-x");
            if (y.Empty())
                throw new ArgumentNullException("null-y");
            if (x.Count() != y.Count())
                throw new ArgumentException("diff-count");
            Points = x.Zip(y, (unx, uny) =>  new Point { x = unx, y = uny } );
        }
    
        private IEnumerable<Point> Points;
        /// <summary>
        /// original points count
        /// </summary>
        public int Count { get { return Points.Count(); } }
        /// <summary>
        /// group points with equal x value, average group y value
        /// </summary>
                                                        public IEnumerable<Point> UniquePoints
    {
        get
        {
            var grp = Points.GroupBy((p) => { return p.x; });
            foreach (IGrouping<float,Point> g in grp)
            {
                float currentX = g.Key;
                float averageYforX = g.Select(p => p.y).Average();
                yield return new Point() { x = currentX, y = averageYforX };
            }
        }
    }
        /// <summary>
        /// count of point set used for interpolation
        /// </summary>
        public int CountUnique { get { return UniquePoints.Count(); } }
        /// <summary>
        /// abscissae
        /// </summary>
        public IEnumerable<float> X { get { return UniquePoints.Select(p => p.x); } }
        /// <summary>
        /// ordinates
        /// </summary>
        public IEnumerable<float> Y { get { return UniquePoints.Select(p => p.y); } }
        /// <summary>
        /// x mean
        /// </summary>
        public float AverageX { get { return X.Average(); } }
        /// <summary>
        /// y mean
        /// </summary>
        public float AverageY { get { return Y.Average(); } }
        /// <summary>
        /// the computed slope, aka regression coefficient
        /// </summary>
        public float Slope { get { return ssxy / ssxx; } }
        // dotvector(x,y)-n*avgx*avgy
        float ssxy { get { return X.DotProduct(Y) - CountUnique * AverageX * AverageY; } }
        //sum squares x - n * square avgx
        float ssxx { get { return X.DotProduct(X) - CountUnique * AverageX * AverageX; } }
        /// <summary>
        /// computed  intercept
        /// </summary>
        public float Intercept { get { return AverageY - Slope * AverageX; } }
        public override string ToString()
        {
            return string.Format("slope:{0:F02} intercept:{1:F02}", Slope, Intercept);
        }
    }
    /// <summary>
    /// any given point
    /// </summary>
     public class Point 
     {
         public float x { get; set; }
         public float y { get; set; }
     }
    /// <summary>
    /// Linq extensions
    /// </summary>
    public static class Extensions 
    {
        /// <summary>
        /// dot vector product
        /// </summary>
        /// <param name="a">input</param>
        /// <param name="b">input</param>
        /// <returns>dot product of 2 inputs</returns>
        public static float DotProduct(this IEnumerable<float> a, IEnumerable<float> b)
        {
            return a.Zip(b, (d1, d2) => d1 * d2).Sum();
        }
        /// <summary>
        /// is empty enumerable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool Empty<T>(this IEnumerable<T> a)
        {
            return a == null || a.Count() == 0;
        }
    }
