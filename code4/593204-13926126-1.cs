    using System.Threading.Tasks;
    private void MyMethod()
    {
        Task.Factory.StartNew(PlaySound1);
        Task.Factory.StartNew(PlaySound2);
    }
    
    private void PlaySound1()
    {
        SoundPlayer wowSound = new SoundPlayer("soundEffect/Wow.wav");
        wowSound.Play();
    }
    
    private void PlaySound2()
    {
        SoundPlayer countingSound = new SoundPlayer("soundEffect/funny.wav");
        countingSound.Play();
    }
