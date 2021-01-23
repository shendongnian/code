        Button button = sender as Button;
        if (button != null)
        {
            var waveDetail = (WaveDetailTag)button.Tag;
            switch (waveDetail.ButtonId)
            {
                case 1:
                    Sound1 = new SoundPlayer((string)button.Tag);
                Sound1.Play();
                break;
            }
        }
