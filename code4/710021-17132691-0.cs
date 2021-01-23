    public interface IManYouCanHit
    {
        bool CanIHitThisGuy;
    }
    public class ManYouCanHit : IManYouCanHit
    {
        public ManYouCanHit(Person someone)
        {
            Man = someone;
        }
        public Person Man { get; private set; }
        public bool CanIHitThisGuy
        {
            get
            {
               //this is not good, better to have IsHittable property on Person class
                return !(Man is RichMan);
            }
        }
    }
