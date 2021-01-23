    public static Surface Screen
    {
        get
        {
            return Surface.FromScreenPtr(Tao.Sdl.Sdl.SDL_GetVideoSurface());
        }
    }
