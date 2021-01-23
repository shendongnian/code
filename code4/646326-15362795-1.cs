    public static class ControlExtensionMethods
    {
        public static IEnumerable<Control> GetOffsprings(this Control @this)
        {
            foreach (Control child in @this.Controls)
            {
                yield return child;
                foreach (var offspring in GetOffsprings(child))
                    yield return offspring;
            }
        }
    }
