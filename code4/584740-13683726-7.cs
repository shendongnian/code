    public abstract class MenuItem
    {
        protected void Foo() {}
    }
    public class SomeTypeOfItem : MenuItem
    {
        protected override void Foo() {}
    }
    
    public class ContainerItem : MenuItem
    {
        void Bar()
        {
            var baseItem = (MenuItem)something;
            baseItem.Foo(); // #1
        }
    }
