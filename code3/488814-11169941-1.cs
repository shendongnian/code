    namespace Test
    {
        public class ClxBasic
        {
            // Define the base function that can be overridden
            // in subclasses.
            public virtual void Update()
            {
                // Do Some Updates
            }
        }
        public class ClxObject : ClxBasic
        {
            // We're overridiung the base function, so we
            // must mark this function as an override.
            public override void Update()
            {
                // Do Some Updates
            }
        }
        public class ClxSprite : ClxObject
        {
            // We're overridiung the base function, so we
            // must mark this function as an override.
            public override void Update()
            {
                // Do Some Updates
            }
        }
    }
