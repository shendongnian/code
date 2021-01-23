    public class ClxSprite : ClxObject
    {
        // We're overridiung the base function, so we
        // must mark this function as an override.
        public override void Update()
        {
            base.Update(); // Will call ClxObject's Update() function
            // Do Some Updates
        }
    }
