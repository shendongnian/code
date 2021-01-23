    public class Character
    {
        public void PickUpItem(Item item)
        {
            if(item.WearerSpecification.SatisfiedBy(this))
            {
                // item can be picked up
            }
            else
            {
                // item can't be picked up
            }
        }
    }
