    void DrawFrame()
    {
        ...
        glMatrixMode( GL_PROJECTION );
        glLoadIdentity();
        gluOrtho2D(0, this.Width, 0, this.Height);
        glMatrixMode( GL_MODELVIEW );
        glLoadIdentity();
        // "camera" transform(s)
        foreach object
        {
            glPushMatrix();
            // per-object matrix transform(s)
            
            // draw object
            glPopMatrix();
        }
    }
