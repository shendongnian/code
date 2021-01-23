    var baseUrl = string.Format("http://api.flickr.com/services/rest/?method=flickr.photos.search&api_key={0}&format=json&nojsoncallback=1", flickrApiKey);
    HttpWebRequest httpRequest = HttpWebRequest.Create(baseUrl) as HttpWebRequest;
    httpRequest.BeginGetResponse(GetResponseStream, httpRequest);
    
    async void GetResponseStream(IAsyncResult callbackResult)
    {
        try
        {
          HttpWebRequest request = (HttpWebRequest)callbackResult.AsyncState;
          HttpWebResponse response = (HttpWebResponse)request.EndGetResponse(callbackResult);
          string responseString = string.Empty;
          Stream streamResponse = response.GetResponseStream();
          StreamReader reader = new StreamReader(streamResponse);
          responseString = reader.ReadToEnd();
        }
        catch (ProtocolViolationException ex)
        {
          MessageDialog show = new MessageDialog("no internet connection available");
        }
        catch (Exception e)
        {
          await Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.Run    Async(CoreDispatcherPriority.Normal, async () =>
        {
          MessageDialog show = new MessageDialog("something went wrong");
          await show.ShowAsync();
          });
        }
      }
