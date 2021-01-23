    public class CustomColorFiringActionProvider : IFiringActionProvider
    {
        private Color color;
        public CustomColorFiringActionProvider(Color c) { this.color = c; }
        public void Fire(Entity e, BulletFactory fact)
        {
            // do something, using color
        }
    }
