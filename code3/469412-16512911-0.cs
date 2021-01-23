    public partial class FormSharpGLTexturesSample : Form
    {
        Capture capture;
        public FormSharpGLTexturesSample()
        {
            InitializeComponent();
            //  Get the OpenGL object, for quick access.
            SharpGL.OpenGL gl = this.openGLControl1.OpenGL;
            //  A bit of extra initialisation here, we have to enable textures.
            gl.Enable(OpenGL.GL_TEXTURE_2D);
            gl.Disable(OpenGL.GL_DEPTH_TEST);
            //  Create our texture object from a file. This creates the texture for OpenGL.
            capture = new Capture(@"Video file here");
        }
        private void openGLControl1_OpenGLDraw(object sender, RenderEventArgs e)
        {
            //  Get the OpenGL object, for quick access.
            SharpGL.OpenGL gl = this.openGLControl1.OpenGL;
            int Width = openGLControl1.Width;
            int Height = openGLControl1.Height;
            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT);
            gl.LoadIdentity();
            var frame = capture.QueryFrame();
            texture.Destroy(gl);
            texture.Create(gl, frame.Bitmap);
            //  Bind the texture.
            texture.Bind(gl);
            gl.Begin(OpenGL.GL_QUADS);
            gl.TexCoord(0.0f, 0.0f); gl.Vertex(0, 0, 0);
            gl.TexCoord(1.0f, 0.0f); gl.Vertex(Width, 0, 0);
            gl.TexCoord(1.0f, 1.0f); gl.Vertex(Width, Height, 0);
            gl.TexCoord(0.0f, 1.0f); gl.Vertex(0, Height, 0);
            gl.End();
            gl.Flush();
        }
        //  The texture identifier.
        Texture texture = new Texture();
        private void openGLControl1_Resized(object sender, EventArgs e)
        {
            SharpGL.OpenGL gl = this.openGLControl1.OpenGL;
            //  Create an orthographic projection.
            gl.MatrixMode(MatrixMode.Projection);
            gl.LoadIdentity();
            // NOTE: Basically no matter what I do, the only points I see are those at
            // the "near" surface (with z = -zNear)--in this case, I only see green points
            gl.Ortho(0, openGLControl1.Width, openGLControl1.Height, 0, 0, 1);
            //  Back to the modelview.
            gl.MatrixMode(MatrixMode.Modelview);
        }
    }
