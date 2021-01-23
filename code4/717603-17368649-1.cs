     private void InitializeKinectScrollViewer()
            {
                KinectRegion.AddHandPointerGotCaptureHandler(this, this.OnHandPointerCaptured);
                KinectRegion.AddHandPointerLostCaptureHandler(this, this.OnHandPointerLostCapture);
                KinectRegion.AddHandPointerEnterHandler(this, this.OnHandPointerEnter);
                KinectRegion.AddHandPointerMoveHandler(this, this.OnHandPointerMove);
                KinectRegion.AddHandPointerPressHandler(this, this.OnHandPointerPress);
                KinectRegion.AddHandPointerGripHandler(this, this.OnHandPointerGrip);
                KinectRegion.AddHandPointerGripReleaseHandler(this, this.OnHandPointerGripRelease);
    //This is the QueryInteractionStatusHandler
                KinectRegion.AddQueryInteractionStatusHandler(this, this.OnQueryInteractionStatus);
                KinectRegion.SetIsGripTarget(this, true);
                this.scrollMoveTimer.Tick += this.OnScrollMoveTimerTick;
                this.scrollViewerInertiaScroller.SlowEnoughForSelectionChanged += this.OnSlowEnoughForSelectionChanged;
    
                // Create KinectRegion binding
                this.kinectRegionBinder = new KinectRegionBinder(this);
                this.kinectRegionBinder.OnKinectRegionChanged += this.OnKinectRegionChanged;    
            }
