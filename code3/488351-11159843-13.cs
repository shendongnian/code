    class Something
    {
        int weight;
        public int SetWeight(int w)
        {
            if (w < 100)
                throw new ArgumentException("weight too small");
            weight = w;
            RecalculateDensity();
        }
        // and other methods
    }
    something.SetWeight(anotherSomething.GetWeight() + 1);
