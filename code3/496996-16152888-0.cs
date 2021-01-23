        public static Surface SetVideoMode(int width, int height, int bitsPerPixel, bool resizable, bool openGL, bool fullScreen, bool hardwareSurface, bool frame)
        {
            /* ... */
            return new Surface(Sdl.SDL_SetVideoMode(width, height, bitsPerPixel, (int)flags), true);
        }
