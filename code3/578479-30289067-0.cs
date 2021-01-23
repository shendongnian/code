    public bool GetCompileStatus(OpenGL gl)
        {
            int[] parameters = new int[] { 0 };
            gl.GetShader(shaderObject, OpenGL.GL_COMPILE_STATUS, parameters);
            return parameters[0] == OpenGL.GL_TRUE;
        }
