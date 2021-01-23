        public static Vector2 MousePositionCamera(Camera camera, GraphicsDevice graphicsDevice)
        {
            Vector2 mousePosition;
            mousePosition.X = Mouse.GetState().X;
            mousePosition.Y = Mouse.GetState().Y;
            //Adjust for resolutions like 800 x 600 that are letter boxed on the Y:
            mousePosition.Y -= Resolution.VirtualViewportY;
            Vector2 screenPosition = Vector2.Transform(mousePosition, Matrix.Invert(Resolution.getTransformationMatrix()));
            Vector2 worldPosition = Vector2.Transform(screenPosition, Matrix.Invert(camera.GetTransformMatrix(graphicsDevice)));
            return worldPosition;     
        }
