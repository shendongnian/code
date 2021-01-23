    public void TrackCallback(IAsyncResult result) {
        if (BackgroundAudioPlayer.Instance.PlayerState == PlayState.Playing && result != null) {
            try {
                // State of request is asynchronous.
                HttpWebRequest trackRequest = (HttpWebRequest)result.AsyncState;
                using (HttpWebResponse trackResponse = (HttpWebResponse)trackRequest.EndGetResponse(result)){
                    XDocument trackXml = XDocument.Load(trackResponse.GetResponseStream());
                    string title = (from t in trackXml.Descendants("channel") select t.Element("title").Value).First<string>();
                    string artist = (from t in trackXml.Descendants("channel") select t.Element("artist").Value).First<string>();
                    if (BackgroundAudioPlayer.Instance.Track != null) {
                        AudioTrack track = BackgroundAudioPlayer.Instance.Track;
                        track.BeginEdit();
                        track.Title = title;
                        track.Artist = artist;
                        track.EndEdit();
                    }
                }
                }
                NotifyComplete();
            } catch (WebException e) {
                Debug.WriteLine(e);
                Debug.WriteLine(e.Response);
            } catch (Exception e) {
                Debug.WriteLine(e);
            }
        }  
    }
