		private void Run() {
			while(true) { // Create an infinite loop
				System.Diagnostics.Debug.WriteLine("PlaybackState: " + this.Wrapper.PlaybackState);
				
				if(this.Wrapper.PlaybackState == PlaybackState.Playing) {
					System.Diagnostics.Debug.WriteLine("Bytes played: " + this.Wrapper.GetPosition());
					
					double ms = this.Wrapper.GetPosition() * 1000.0 / this.Wrapper.OutputWaveFormat.BitsPerSample / this.Wrapper.OutputWaveFormat.Channels * 8 / this.Wrapper.OutputWaveFormat.SampleRate;
					
					System.Diagnostics.Debug.WriteLine("Milliseconds Played: " + ms);
				}
				
				Thread.Sleep(1000); // Sleep for 1 second
			}
		}
