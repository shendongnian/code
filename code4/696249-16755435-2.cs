    internal Tao.Sdl.Sdl.SDL_Surface SurfaceStruct
    {
        get
        {
            if (this.disposed)
            {
                throw new ObjectDisposedException(this.ToString());
            }
            GC.KeepAlive(this);
            return (Tao.Sdl.Sdl.SDL_Surface) Marshal.PtrToStructure(base.Handle, typeof(Tao.Sdl.Sdl.SDL_Surface));
        }
    }
 
 
