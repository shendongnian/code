    public class MakeSoundCommand : ICommand
    {
        public bool CanExecute(object parameter)
        {
            return true;
        }
        public event EventHandler CanExecuteChanged;
        public void Execute(object parameter)
        {
            Uri uri = parameter as Uri;
            if (uri != null)
            {
                StreamResourceInfo sri = Application.GetResourceStream(uri);
                SoundPlayer simpleSound = new SoundPlayer(sri.Stream);
                simpleSound.Play();
            }
        }
