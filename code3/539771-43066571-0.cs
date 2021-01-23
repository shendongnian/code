    class Fader
    {
        // Class properties
        private Timer          timer;          // The timer used to control the forms opacity.
        private Form           form;           // The form to modify the opacity of.
        private FadeDirection  fadeDirection;  // The direction in which to fade.
        private float          fadeSpeed;      // The speed at which to fade.
        // Enum for controlling the fade direction.
        private enum FadeDirection
        {
            In,
            Out
        }
        // Constants for setting the fade speed. 
        // (You can alternately use a custom float value)
        public struct FadeSpeed
        {
            public static readonly float Slowest = 001;
            public static readonly float Slower  = 010;
            public static readonly float Slow    = 025;
            public static readonly float Normal  = 050;
            public static readonly float Fast    = 060;
            public static readonly float Faster  = 075;
            public static readonly float Fastest = 100;
        }
        /// <summary>
        /// An object used to control fading forms in and out.
        /// </summary>
        /// <param name="form">The form that will be faded.</param>
        /// <param name="fadeSpeed">The speed at which to fade.</param>
        public Fader(Form form, float fadeSpeed)
        {
            this.form = form;
            this.fadeSpeed = fadeSpeed;
            timer = new Timer();
            timer.Interval = 1;
            timer.Tick += new EventHandler(updateOpacity);
            timer.Enabled = true;
        }
        /// <summary>
        /// Update the opacity of the form using the timer.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void updateOpacity(object sender, EventArgs e)
        {
            switch (fadeDirection)
            {
                // Fade in
                case FadeDirection.In:
                    if (form.Opacity != 1)
                    {
                        form.Opacity += (fadeSpeed / 1000);
                    }
                    else
                    {
                        timer.Stop();
                    }
                    break;
                // Fade out
                case FadeDirection.Out:
                    if (form.Opacity != 0)
                    {
                        form.Opacity -= (fadeSpeed / 1000);
                    }
                    else
                    {
                        timer.Stop();
                    }
                    break;
            }
        }
        /// <summary>
        /// Fade the form in at the defined speed.
        /// </summary>
        public void fadeIn()
        {
            form.Opacity = 0;
            fadeDirection = FadeDirection.In;
            timer.Start();
        }
        /// <summary>
        /// Fade the form out at the defined speed.
        /// </summary>
        public void fadeOut()
        {
            form.Opacity = 1;
            fadeDirection = FadeDirection.Out;
            timer.Start();
        }
        /// <summary>
        /// Fade a form in at the defined speed.
        /// </summary>
        public static void FadeIn(Form form, float fadeSpeed)
        {
            Fader fader = new Fader(form, fadeSpeed);
            fader.fadeIn();
        }
        /// <summary>
        /// Fade a form out at the defined speed.
        /// </summary>
        public static void FadeOut(Form form, float fadeSpeed)
        {
            Fader fader = new Fader(form, fadeSpeed);
            fader.fadeOut();
        }
    }
