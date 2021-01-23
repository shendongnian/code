            var parameters = new TransformSmoothParameters
            {
                Smoothing = 0.2f,
                Correction = 0.0f,
                Prediction = 0.0f,
                JitterRadius = 1.0f,
                MaxDeviationRadius = 0.5f
            };
            this._sensor.SkeletonStream.Enable(parameters);
