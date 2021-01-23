    abstract class Astro
    {
        protected int metal;
        protected int gas;
        protected int crystals;
        protected int fertility;
        protected int area;
        public int Metal { get { return metal; } }
        public int Gas { get { return gas; } }
        public int Crystals { get { return crystals; } }
        public int Fertility { get { return fertility; } }
        public int Area { get { return area; } }
    }
    class BaseCalc
    {
        private int metal;
        private int gas;
        private int crystals;
        private int fertility;
        private int area;
        //private List<Structure> structures = new List<Structure>();
        private int position;
        private Astro selectedAstro;
        public BaseCalc(Astro astro, int position)
        {
            this.selectedAstro = astro;
            this.metal = selectedAstro.Metal;
            this.gas = selectedAstro.Gas;
            this.crystals = selectedAstro.Crystals;
            this.fertility = selectedAstro.Fertility;
            this.area = selectedAstro.Area;
            this.position = position;
            //Code ommited
        }
    }
