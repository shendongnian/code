    public interface IMainView {
       void ChangeTheme(string themeName);
    }
    public class ViewModel {
       public IMainView View { get; } //get the view somehow
       public ICommand ChangeThemeCommand { get; }
       private void OnChangeThemeCommandExecute(string themeName) {
          View.ChangeTheme(themeName);
       }
    }
