        /// <summary>
        /// Gets the surface for the window or screen,
        /// must be preceded by a call to SetVideoMode
        /// </summary>
        /// <returns>The main screen surface</returns>
        public static Surface Screen
        {
            get
            {
                return Surface.FromScreenPtr(Sdl.SDL_GetVideoSurface());
            }
        }
