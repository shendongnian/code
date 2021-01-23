        public static double VectorMagnitude(this Color c, Color otherC)
        {
            return Math.Sqrt(((int)(c.R + otherC.R))^2 + 
                ((int)(c.G + otherC.G))^2 + 
                ((int)(c.B + otherC.B))^2); 
        }
        private static List<Color> Colors()
        {
            return new List<Color>()
            {
                Color.Red,
                Color.Blue,
                Color.FromArgb(0,255,0)
            };
        }
     var l = Colors().OrderBy(x => x.VectorMagnitude(
                    Color.FromArgb(255, R, G, B))).FirstOrDefault();
