    async void TrimFile(StorageFile srcFile, StorageFile destFile)
    {
        MediaEncodingProfile profile =
            MediaEncodingProfile.CreateMp4(VideoEncodingQuality.HD720p);
    
        MediaTranscoder transcoder = new MediaTranscoder();
    
        // Set the start of the trim.
        transcoder.TrimStartTime = new TimeSpan(0, 0, 1);
    
        // Set the end of the trim.
        transcoder.TrimStopTime = new TimeSpan(0, 0, 9);
    
        PrepareTranscodeResult prepareOp = await
            transcoder.PrepareFileTranscodeAsync(srcFile, destFile, profile);
    
        if (prepareOp.CanTranscode)
        {
            var transcodeOp = prepareOp.TranscodeAsync();
            transcodeOp.Progress +=
                new AsyncActionProgressHandler<double>(TranscodeProgress);
            transcodeOp.Completed +=
                new AsyncActionWithProgressCompletedHandler<double>(TranscodeComplete);
        }
        else
        {
            switch (prepareOp.FailureReason)
            {
                case TranscodeFailureReason.CodecNotFound:
                    OutputText("Codec not found.");
                    break;
                case TranscodeFailureReason.InvalidProfile:
                    OutputText("Invalid profile.");
                    break;
                default:
                    OutputText("Unknown failure.");
                    break;
            }
        }
    }
