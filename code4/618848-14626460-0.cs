        /// <summary>
        /// Creates a Ray translating screen cursor position into screen position
        /// </summary>
        /// <param name="projectionMatrix"></param>
        /// <param name="viewMatrix"></param>
        /// <returns></returns>
        public Ray CalculateCursorRay(Matrix projectionMatrix, Matrix viewMatrix)
        {
            // create 2 positions in screenspace using the cursor position. 0 is as
            // close as possible to the camera, 1 is as far away as possible.
            Vector3 nearSource = new Vector3(mousePosition, 0f);
            Vector3 farSource = new Vector3(mousePosition, 1f);
            // use Viewport.Unproject to tell what those two screen space positions
            // would be in world space. we'll need the projection matrix and view
            // matrix, which we have saved as member variables. We also need a world
            // matrix, which can just be identity.
            Vector3 nearPoint = GraphicsDevice.Viewport.Unproject(nearSource,
                projectionMatrix, viewMatrix, Matrix.Identity);
            Vector3 farPoint = GraphicsDevice.Viewport.Unproject(farSource,
                projectionMatrix, viewMatrix, Matrix.Identity);
            // find the direction vector that goes from the nearPoint to the farPoint
            // and normalize it....
            Vector3 direction = farPoint - nearPoint;
            direction.Normalize();
            // and then create a new ray using nearPoint as the source.
            return new Ray(nearPoint, direction);
        }
        private Vector3 cursorRayToCoords(Ray ray, Vector3 cameraPos)
        {
            Nullable<float> distance = ray.Intersects(new Plane(Vector3.Up, 0.0f));
            if (distance == null)
                return Vector3.Zero;
            else
            {
                return cameraPos + ray.Direction * (float)distance;
            }
        }
        public override void Update(GameTime gameTime)
        {
            cursorRay = CalculateCursorRay(camera.Projection, camera.View);
            cursorOnMapPos = cursorRayToCoords(cursorRay, cursorRay.Position);
            checkInput(gameTime);
            base.Update(gameTime);
        }
        /// <summary>
        /// Returns the nearest unit to the cursor
        /// </summary>
        /// <returns>The unit nearest to the cursor</returns>
        private Unit getCursorUnit()
        {
            Unit closestUnit = null;
            float? nearestDistance = null;
            float? checkIntersect = null;
            foreach (Unit unit in map.Units)//checks to see if unit selection
            {
                checkIntersect = cursorRay.Intersects(unit.BoundingSphere);
                if (checkIntersect != null)//if intersection detected
                {
                    if (nearestDistance == null) //first unit found
                    {
                        closestUnit = unit;
                        nearestDistance = (float)checkIntersect;
                    }
                    else if ((float)checkIntersect < (float)nearestDistance)//for any others, only find the nearest
                    {
                        closestUnit = unit;
                        nearestDistance = (float)checkIntersect;
                    }
                }
            }
            return closestUnit;
        }
