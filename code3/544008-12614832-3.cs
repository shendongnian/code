    public class FooController
    {
        public virtual ActionResult Bar()
        {
            return View();
        }
    }
    public class Foo1Controller : FooController
    {
        public override ActionResult Bar()
        {
            return View();
        }
    }
    public class Foo2Controller : FooController
    {
    }
