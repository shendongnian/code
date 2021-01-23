        void UpdateView()
        {
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(_viewRect.X, _viewRect.X + _viewRect.Width, _viewRect.Y + _viewRect.Height, _viewRect.Y, -1, 1);
            glControl1.Invalidate();
            this.Text = string.Format("{0},{1} {2}x{3}", _viewRect.X, _viewRect.Y, _viewRect.Width, _viewRect.Height);
        }
