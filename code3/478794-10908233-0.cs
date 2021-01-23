        private void openGLControl1_OpenGLDraw(object sender,     SharpGL.SceneGraph.OpenGLEventArgs args)
        {
            // NOTE: Only draw once after m_drawCount is set to zero
            if (m_drawCount < 1)
            {
                //  Get the OpenGL instance.
                var gl = args.OpenGL;
                // ADDED THIS LINE
                gl.Clear(SharpGL.OpenGL.GL_DEPTH_BUFFER_BIT);
                gl.Color(1f, 0f, 0f);
                gl.PointSize(2.0f);
                //  Draw 10000 random points.
                gl.Begin(BeginMode.Points);
                Random random = new Random();
                for (int i = 0; i < 10000; i++)
                {
                    double x = 10 + 400 * random.NextDouble();
                    double y = 10 + 400 * random.NextDouble();
                    double z = (double)random.Next(-10, 0);
                    // Color the point according to z value
                    gl.Color(0f, 0f, 1f);  // default to blue
                    if (z == -9)
                        gl.Color(1f, 0f, 0f);   // Red for z = -10
                    else if (z == -1)
                        gl.Color(0f, 1f, 0f);   // Green for z = -1
                    gl.Vertex(x, y, z);
                }
                    gl.End();
                    m_drawCount++;
                }
            }
