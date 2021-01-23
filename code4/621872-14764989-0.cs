           FaceTrackFrame faceFrame = faceTracker.Track(
                kinectSensor.ColorStream.Format, colorPixelData,
                kinectSensor.DepthStream.Format, depthPixelData, skeleton);
            
            // Only works if face is detected
            if (faceFrame.TrackSuccessful)
            {
                txtTracked.Content = "TRACKED";
                txtRoll.Content = faceFrame.Rotation.Z;
                txtPitch.Content = faceFrame.Rotation.X;
                txtYaw.Content = faceFrame.Rotation.Y;
            }
