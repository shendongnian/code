        /// <summary>
        /// Creates a double animation.
        /// </summary>
        /// <param name="from">From position</param>
        /// <param name="to">To position</param>
        /// <param name="duration">The duration.</param>
        /// <param name="delay">The delay.</param>
        /// <param name="autoreverse">if set to <c>true</c> [autoreverse].</param>
        /// <param name="repeat">The times to repeat.</param>
        /// <returns>new double animation</returns>
        public static DoubleAnimationUsingKeyFrames GetDoubleAnimation(double from, double to, int duration, int delay, bool autoreverse, int repeat)
            {
                var doubleanimation = new DoubleAnimationUsingKeyFrames();
                doubleanimation.AutoReverse = autoreverse;
                doubleanimation.IsAdditive = false;
                Storyboard.SetDesiredFrameRate(doubleanimation, 30);
                doubleanimation.IsCumulative = false;
                doubleanimation.BeginTime = new TimeSpan(0, 0, 0, 0, delay);
                doubleanimation.Duration = new Duration(TimeSpan.FromMilliseconds(duration));
                doubleanimation.RepeatBehavior = repeat == -1 ? RepeatBehavior.Forever : new RepeatBehavior(repeat);
                EasingDoubleKeyFrame start = new EasingDoubleKeyFrame(from, KeyTime.FromPercent(0));
                EasingDoubleKeyFrame end = new EasingDoubleKeyFrame(to, KeyTime.FromPercent(1.0));
                doubleanimation.KeyFrames.Add(start);
                doubleanimation.KeyFrames.Add(end);
                return doubleanimation;
            }
