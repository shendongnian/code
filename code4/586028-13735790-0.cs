        /// <summary>
        /// If camera has not been initialized when navigating to this page, initialization
        /// will be started asynchronously in this method. Once initialization has been
        /// completed the camera will be set as a source to the VideoBrush element
        /// declared in XAML. On-screen controls are enabled when camera has been initialized.
        /// </summary>
        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (_dataContext.Device == null)
            {
                ShowProgress("Initializing camera...");
                await InitializeCamera(CameraSensorLocation.Back);
                HideProgress();
            }
            videoBrush.RelativeTransform = new CompositeTransform()
            {
                CenterX = 0.5,
                CenterY = 0.5,
                Rotation = _dataContext.Device.SensorLocation == CameraSensorLocation.Back ?
                           _dataContext.Device.SensorRotationInDegrees :
                         - _dataContext.Device.SensorRotationInDegrees
            };
            videoBrush.SetSource(_dataContext.Device);
            overlayComboBox.Opacity = 1;
            SetScreenButtonsEnabled(true);
            SetCameraButtonsEnabled(true);
            base.OnNavigatedTo(e);
        }
        /// <summary>
        /// Initializes camera. Once initialized the instance is set to the DataContext.Device property
        /// for further usage from this or other pages.
        /// </summary>
        /// <param name="sensorLocation">Camera sensor to initialize</param>
        private async Task InitializeCamera(CameraSensorLocation sensorLocation)
        {
            Windows.Foundation.Size initialResolution = new Windows.Foundation.Size(640, 480);
            Windows.Foundation.Size previewResolution = new Windows.Foundation.Size(640, 480);
            Windows.Foundation.Size captureResolution = new Windows.Foundation.Size(640, 480);
            PhotoCaptureDevice d = await PhotoCaptureDevice.OpenAsync(sensorLocation, initialResolution);
            await d.SetPreviewResolutionAsync(previewResolution);
            await d.SetCaptureResolutionAsync(captureResolution);
            d.SetProperty(KnownCameraGeneralProperties.EncodeWithOrientation,
                          d.SensorLocation == CameraSensorLocation.Back ?
                          d.SensorRotationInDegrees : - d.SensorRotationInDegrees);
            _dataContext.Device = d;
        }
