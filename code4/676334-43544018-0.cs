    using System.Linq;
    ...
    public static bool IsOpen(this Window window)
    {
        return Application.Current.Windows.Cast<Window>().Any(x => x == window);
    }
