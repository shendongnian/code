    this.sensor.DepthFrameReady += this.Sensor_DepthFrameReady;
    this.interaction = new InteractionStream(sensor, new InteractionClient());
    this.interaction.InteractionFrameReady += interaction_InteractionFrameReady;
    ...
    private void Sensor_DepthFrameReady(object sender, DepthImageFrameReadyEventArgs e)
    {
        using (var frame = e.OpenDepthImageFrame())
        {
            if (frame != null)
            {
                try
                {
                    interaction.ProcessDepth(frame.GetRawPixelData(), frame.Timestamp);
                }
                catch (InvalidOperationException) { }
            }
        }
    }
    private void interaction_InteractionFrameReady(object sender, InteractionFrameReadyEventArgs e)
    {
        using (var frame = e.OpenInteractionFrame())
        {
            if (frame != null)
            {
                if ((interactionData == null) || 
                    (interactionData.Length !== InteractionStream.FrameUserInfoArrayLength))
                {
                    interactionData = new UserInfo[InteractionStream.FrameUserInfoArrayLength];
                }
                frame.CopyInteractionDataTo(interactionData);
                foreach (var ui in interactionData)
                {
                    foreach (var hp in ui.HandPointers)
                    {
                        // Get screen coordinates
                        var screenX = hp.X * DisplayWidth;
                        var screenY = hp.Y * DisplayHeight;
                        // You can also access IsGripped, IsPressed etc.
                    }
                }
            }
        }
    }
    public class InteractionClient: IInteractionClient
    {
        public InteractionInfo GetInteractionInfoAtLocation(
            int skeletonTrackingId,
            InteractionHandType handType,
            double x, double y)
        {
            return new InteractionInfo();
        }
    }
