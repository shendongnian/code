        private class Val
        {
            public double A;
            public double B;
            public double X;
            public double ParallellResult;
        }
    
        private static void findParallellError()
        {
            var r = new Random();
    
            while (true)
            {
                var vals = new List<Val>();
                for (var i = 0; i < 1000*1000; i++)
                {
                    var val = new Val();
                    val.A = r.NextDouble()*100;
                    val.B = val.A + r.NextDouble()*1000;
                    val.X = r.NextDouble();
                    vals.Add(val);
                }
    
                // parallell calculation
                vals.AsParallel().ForAll(v => v.ParallellResult = Boost.BoostMath.InverseIncompleteBeta(v.A, v.B, v.X));
    
                /sequential verification
                var error = vals.Exists(v => v.ParallellResult != Boost.BoostMath.InverseIncompleteBeta(v.A, v.B, v.X));
                if (error)
                    return;
            }
        }
