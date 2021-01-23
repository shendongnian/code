        double beamAngle, sourceAngle;
        ...
        private void AudioSourceBeamChanged(object sender, BeamAngleChangedEventArgs e)
        {
            beamRotation.Angle = -e.Angle;
            beamAngle = e.Angle;
            beamAngleText.Text = string.Format(CultureInfo.CurrentCulture, Properties.Resources.BeamAngle, e.Angle.ToString("0", CultureInfo.CurrentCulture));
        }
        private void AudioSourceBeamChanged(object sender, BeamAngleChangedEventArgs e)
        {
            beamRotation.Angle = -e.Angle;
            beamAngle = e.Angle;
            beamAngleText.Text = string.Format(CultureInfo.CurrentCulture, Properties.Resources.BeamAngle, e.Angle.ToString("0", CultureInfo.CurrentCulture));
        }
        private void AudioReadingThread()
        {
            // Bottom portion of computed energy signal that will be discarded as noise.
            // Only portion of signal above noise floor will be displayed.
            const double EnergyNoiseFloor = 0.2;
            while (this.reading)
            {
                while (beamAngle == 0 && sourceAngle == 0) //this is the important part
                {
                    int readCount = audioStream.Read(audioBuffer, 0, audioBuffer.Length);
                    // Calculate energy corresponding to captured audio in the dispatcher
                    // (UI Thread) context, so that rendering code doesn't need to
                    // perform additional synchronization.
                    Dispatcher.BeginInvoke(
                    new Action(
                        () =>
                        {
                            for (int i = 0; i < readCount; i += 2)
                            {
                                // compute the sum of squares of audio samples that will get accumulated
                                // into a single energy value.
                                short audioSample = BitConverter.ToInt16(audioBuffer, i);
                                this.accumulatedSquareSum += audioSample * audioSample;
                                ++this.accumulatedSampleCount;
                                if (this.accumulatedSampleCount < SamplesPerColumn)
                                {
                                    continue;
                                }
                                // Each energy value will represent the logarithm of the mean of the
                                // sum of squares of a group of audio samples.
                                double meanSquare = this.accumulatedSquareSum / SamplesPerColumn;
                                double amplitude = Math.Log(meanSquare) / Math.Log(int.MaxValue);
                                // Renormalize signal above noise floor to [0,1] range.
                                this.energy[this.energyIndex] = Math.Max(0, amplitude - EnergyNoiseFloor) / (1 - EnergyNoiseFloor);
                                this.energyIndex = (this.energyIndex + 1) % this.energy.Length;
                                this.accumulatedSquareSum = 0;
                                this.accumulatedSampleCount = 0;
                                ++this.newEnergyAvailable;
                            }
                        }));
                }
            }
