	/// <summary>
	/// Event handler for Kinect sensor's DepthFrameReady event
	/// </summary>
	/// <param name="sender">object sending the event</param>
	/// <param name="e">event arguments</param>
	private void SensorDepthFrameReady(object sender, DepthImageFrameReadyEventArgs e)
	{
		using (DepthImageFrame depthFrame = e.OpenDepthImageFrame())
		{
			if (depthFrame != null)
			{
				// Copy the pixel data from the image to a temporary array
				depthFrame.CopyDepthImagePixelDataTo(this.depthPixels);
				// Get the min and max reliable depth for the current frame
				int minDepth = depthFrame.MinDepth;
				int maxDepth = depthFrame.MaxDepth;
				// Convert the depth to RGB
				int colorPixelIndex = 0;
				for (int i = 0; i < this.depthPixels.Length; ++i)
				{
					// Get the depth for this pixel
					short depth = depthPixels[i].Depth;
					// To convert to a byte, we're discarding the most-significant
					// rather than least-significant bits.
					// We're preserving detail, although the intensity will "wrap."
					// Values outside the reliable depth range are mapped to 0 (black).
					// Note: Using conditionals in this loop could degrade performance.
					// Consider using a lookup table instead when writing production code.
					// See the KinectDepthViewer class used by the KinectExplorer sample
					// for a lookup table example.
					byte intensity = (byte)(depth >= minDepth && depth <= maxDepth ? depth : 0);
					// Write out blue byte
					this.colorPixels[colorPixelIndex++] = intensity;
					// Write out green byte
					this.colorPixels[colorPixelIndex++] = intensity;
					// Write out red byte                        
					this.colorPixels[colorPixelIndex++] = intensity;
											
					// We're outputting BGR, the last byte in the 32 bits is unused so skip it
					// If we were outputting BGRA, we would write alpha here.
					++colorPixelIndex;
				}
				// Write the pixel data into our bitmap
				this.colorBitmap.WritePixels(
					new Int32Rect(0, 0, this.colorBitmap.PixelWidth, this.colorBitmap.PixelHeight),
					this.colorPixels,
					this.colorBitmap.PixelWidth * sizeof(int),
					0);
			}
		}
	}
