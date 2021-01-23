    public interface IManYouCanHit
    {
        bool CanIHitThisGuy;
    }
    public class ManYouCanHit : IManYouCanHit
    {
        public ManYouCanHit(Person someone)
        {
            if (!(someone is RichMan) && !(someone is TaxiDriver))
                throw;
            Man = someone;
        }
        public Person Man { get; private set; }
        public bool CanIHitThisGuy
        {
            get
            {
               //this is not good, better to have IsHittable property on Person class
               //so that you can return just Man.IsHittable
                return !(Man is RichMan);
            }
        }
    }
