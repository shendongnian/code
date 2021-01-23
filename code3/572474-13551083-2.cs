    int videoWidth = (int)shellFile.Properties.System.Video.FrameWidth.Value;
    int videoHeight = (int)shellFile.Properties.System.Video.FrameHeight.Value;
    int horizontalAspect = (int)shellFile.Properties.System.Video.HorizontalAspectRatio.Value;
    int verticalAspect = (int)shellFile.Properties.System.Video.VerticalAspectRatio.Value;
    int displayWidth = videoWidth * horizontalAspect / verticalAspect;
    int displayHeight = videoHeight;
