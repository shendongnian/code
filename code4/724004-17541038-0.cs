    captureDevice.PreviewFrameAvailable += new Windows.Foundation.TypedEventHandler<ICameraCaptureDevice, object>(VideoPreviewFrameAvailable);
    public void VideoPreviewFrameAvailable(ICameraCaptureDevice a, object b)
    {
        nFrameCount++;
    }
