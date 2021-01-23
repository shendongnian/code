    public class Deer : Animal
    {
        Wolf _hunter;
        public void SetHunter(Wolf wolf)
        {
            _hunter = wolf;
        }
        public void Hide()
        {
            if (_hunter != null)
            {
                Feedback = "The deer is hiding.";
            }
            else
            {
                //Forage();
            }
        }
    }
