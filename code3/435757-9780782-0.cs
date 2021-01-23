    private void SetupViewport()
    {
      int w = glControl1.Width;
      int h = glControl1.Height;
      GL.MatrixMode(MatrixMode.Projection);
      GL.LoadIdentity();
      GL.Ortho(0, w, 0, h, -1, 1); // Bottom-left corner pixel has coordinate (0, 0)
      GL.Viewport(0, 0, w, h); // Use all of the glControl painting area
    }
