    public class Item
    {
        public virtual bool IsWearable(Character c)
        {
            return true;
        }
    }
    public class BananaSword : Item
    {
        public override bool IsWearable(Character c)
        {
             return c.Level >= 10 && c.Race == CharacterRace.BananaWarrior;
        }
    }
    public class BananaDude : Character
    {
        public List<Item> GetWearableItems()
        {
            return AllGameItems.Where(i => i.IsWearable(this)).ToList();
        }
    }
