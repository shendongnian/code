    void speech_PhonemeReached(object sender, PhonemeReachedEventArgs e)
    {
        if (new[] {"a͡i","o"}.Contains(e.Phoneme))
           this.Invoke(new Action(() => { MessageBox.Show(this, e.Phoneme); }));
    }
