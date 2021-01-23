        MediaCapture mediaCapture;
        DeviceInformationCollection devices;
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            devices = await DeviceInformation.FindAllAsync(DeviceClass.VideoCapture);
            this.mediaCapture = new MediaCapture();
            if (devices.Count() > 0)
            {
                await this.mediaCapture.InitializeAsync(new MediaCaptureInitializationSettings { VideoDeviceId = devices.ElementAt(1).Id, PhotoCaptureSource = Windows.Media.Capture.PhotoCaptureSource.VideoPreview });
                SetResolution();
            }  
        }
        //This is how you can set your resolution
        public async void SetResolution()
        {
            System.Collections.Generic.IReadOnlyList<IMediaEncodingProperties> res;
            res = this.mediaCapture.VideoDeviceController.GetAvailableMediaStreamProperties(MediaStreamType.VideoPreview);
            uint maxResolution = 0;
            int indexMaxResolution = 0;
            if (res.Count >= 1)
            {
                for (int i = 0; i < res.Count; i++)
                {
                    VideoEncodingProperties vp = (VideoEncodingProperties)res[i];
                    if (vp.Width > maxResolution)
                    {
                        indexMaxResolution = i;
                        maxResolution = vp.Width;
                        Debug.WriteLine("Resolution: " + vp.Width);
                    }
                }
                await this.mediaCapture.VideoDeviceController.SetMediaStreamPropertiesAsync(MediaStreamType.VideoPreview, res[indexMaxResolution]);
            }
        }
