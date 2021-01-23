    public class FooController
    {
        public virtual ActionResult Bar()
        {
        }
        // COMPILER ERROR here, there's nothing to override
        public override ActionResult Bar()
        {
        }
    }
