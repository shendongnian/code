    public class WhackAMoleViewModel: PropertyChangedBase
    {
        private List<Mole> _moles;
        public List<Mole> Moles
        {
            get { return _moles; }
        }
        private System.Threading.Timer timer;
        private System.Random random = new Random();
        public WhackAMoleViewModel()
        {
            _moles = Enumerable.Range(1, 9).Select(x => new Mole()).ToList();
            timer = new Timer(x => RaiseRandomMole(), null, 0, 300);
        }
        private void RaiseRandomMole()
        {
            //If random number is less than 5 skip this iteration
            if (random.Next(1, 10) > 5)
                return;
            //Choose a random mole
            var mole = Moles[random.Next(0, 8)];
            //If it's already raised, do nothing
            if (mole.IsUp)
                return;
            //Raise it
            mole.IsUp = true;
            //Then Get it down somewhere between 1 and 2 seconds after
            Task.Factory.StartNew(() => Thread.Sleep(random.Next(1000, 2000)))
                        .ContinueWith(x => mole.IsUp = false);
        }
    }
