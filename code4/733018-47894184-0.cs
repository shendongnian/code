    static class Helper
    {
        public static IEnumerable<Product> Except(this List<Product> x, List<Product> y)
        {
            foreach(var xi in x)
            {
                bool found = false;
                foreach (var yi in y) { if(xi.Name == yi.Name) { found = true; } }
                if(!found) { yield return xi; }
            }
        }
    }
