    public class Wolf : Animal
    {
        public void Hunt(Deer deer)
        {
            deer.SetHunter(this);
        }
    }
