    A user of the Tao Framework implemented this idea with promising results. He wrote wrappers for OpenGL resources and implemented the disposable pattern like this:
    private void Dispose(bool manual)
    {
        if (!disposed)
        {
            if (manual)
            {
                 Gl.glDeleteTextures(1, ref _tid);
                 GC.SuppressFinalize(this);
                 disposed = true;
            }
            else
            {
                GC.KeepAlive(SimpleOpenGlControl.DisposingQueue);
                SimpleOpenGlControl.DisposingQueue.Enqueue(this);
            }
        }
    }
