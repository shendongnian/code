    public void PlaySound(string soundFile)
    {
        using (var stream = TitleContainer.OpenStream(soundFile))
        {
            var effect = SoundEffect.FromStream(stream);
            FrameworkDispatcher.Update();
            effect.Play();
        }
    }
