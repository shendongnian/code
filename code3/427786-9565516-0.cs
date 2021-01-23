    using System.Linq;
    public IEnumerable<T> GetUIElements<T>() where T : DependencyObject
    {
        return myCanvas.Children.OfType<T>();
    }
