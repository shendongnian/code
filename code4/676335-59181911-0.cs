csharp
public bool IsWindowOpen<T>(string name = "") where T : Window
{
    return Application.Current.Windows.OfType<T>().Any(w => w.GetType().Name.Equals(name));               
}
