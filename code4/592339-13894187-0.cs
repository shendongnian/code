    public class Entity : Container {
        public string Foo = "Bar";
        public virtual void Add(IComponent component) {
            if (!typeof(Position).IsAssignableFrom(component.GetType())) {
                throw new ArgumentException(...);
            }
            base.Add(component);
        }
    }
