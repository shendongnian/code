    var sri = Application.GetResourceStream(new Uri("pack://application:,,,/MyAssemblyName;component/Resources/CameraShutter.wav"));
    if ((sri != null)) 
    {
      using (s == sri.Stream) 
      {
        System.Media.SoundPlayer player = new System.Media.SoundPlayer(s);
        player.Load();
        player.Play();
      }
    }
