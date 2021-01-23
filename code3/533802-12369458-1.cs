    private void slider_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            if(mute)
            {
            MediaElement.IsMuted = false;
            mute = false;
            MediaElement.Volume = (slider.Value)/100;
            }
            else
            {
                MediaElement.Volume = (slider.Value) / 100;
            }
        }
