    public interface IHasNavigationProperty {
        NavigationProperty NavigationProperty { get; }
    }
    public class Child1 : Base, IHasNavigationProperty {
        public NavigationProperty NavigationProperty { get; set; }
    }
    public class Base {
        public void AMethodThatDoesStuff() {
            if (this is IHasNavigationProperty) {
                var navigationProperty = ((IHasNavigationProperty)this).NavigationProperty;
                /* do stuff with NavigationProperty */
            }
        }
    }
