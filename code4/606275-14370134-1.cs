            if (BackgroundAudioPlayer.Instance.PlayerState == PlayState.Stopped)
            {
                for (int i = 0; i < AudioList.Count; i++)
                {
                    if (AudioList[i].Url1 == currTrack)
                    {
                        AudioList[i].IsPlaing = false;
                        currTrack = AudioList[i + 1].Url1;
                        AudioList[i + 1].IsPlaing = true;
                        break;
                    }
                        
                    }
                }
                BackgroundAudioPlayer.Instance.Play();
            }
 
