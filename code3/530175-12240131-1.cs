    public bool InsertVideo()
        {
            Trace.TraceInformation("Entering InsertVideo: starting a new upload");
            Video newVideo = new Video();
            newVideo.Title = "MY video";
            newVideo.Tags.Add(new MediaCategory("Autos", YouTubeNameTable.CategorySchema));
            newVideo.Keywords = "education, funny deneme";
            newVideo.Description = "bilgi mi istiyorsun";
            newVideo.YouTubeEntry.Private = false;
            newVideo.Tags.Add(new MediaCategory("mydevtag, anotherdevtag",
              YouTubeNameTable.DeveloperTagSchema));
            newVideo.YouTubeEntry.MediaSource = new MediaFileSource("c:\\cat.flv",
              "video/quicktime");
            // newVideo.Private = true;
            GDataCredentials credentials = new GDataCredentials(UserName, PassWord);
            Authenticator youTubeAuthenticator =new ClientLoginAuthenticator("YoutubeUploader",
                        ServiceNames.YouTube, credentials);
            youTubeAuthenticator.DeveloperKey = DevKey;
            AtomLink link = new AtomLink("http://uploads.gdata.youtube.com/resumable/feeds/api/users/" + UserName + "/uploads");
            link.Rel = ResumableUploader.CreateMediaRelation;
            newVideo.YouTubeEntry.Links.Add(link);
            ResumableUploader ru = new ResumableUploader();
            ru.AsyncOperationCompleted += new AsyncOperationCompletedEventHandler(this.OnDone);
            ru.AsyncOperationProgress += new AsyncOperationProgressEventHandler(this.OnProgress);
            var tmpvalue = "bla bla bla";
            ru.InsertAsync(youTubeAuthenticator, newVideo.YouTubeEntry, tmpvalue);
            return true;
        }
        private void OnProgress(object sender, AsyncOperationProgressEventArgs e)
        {
           Debug.WriteLine("It has been completed : " + e.ProgressPercentage);
        }
        private void OnDone(object sender, AsyncOperationCompletedEventArgs e)
        {
            
            Debug.WriteLine("It has Done");
        }
