        /// <summary>
        /// Rotate a vector around pivot.
        /// </summary>
        /// <param name="vec">Vector to rotate.</param>
        /// <param name="pivot">Point to rotate around.</param>
        /// <param name="theta">Rotation angle.</param>
        /// <returns>Rotated vector.</returns>
        public static Vector2 RotateAround(Vector2 vec, Vector2 pivot, float theta)
        {
            return new Vector2(
                (float)(System.Math.Cos(theta) * (vec.X - pivot.X) - System.Math.Sin(theta) * (vec.Y - pivot.Y) + pivot.X),
                (float)(System.Math.Sin(theta) * (vec.X - pivot.X) + System.Math.Cos(theta) * (vec.Y - pivot.Y) + pivot.Y));
        }
        /// <summary>
        /// Get rectangle and rotation (angle + origin) and calculate bounding box containing the rotated rect.
        /// </summary>
        /// <param name="rect">Rectangle to rotate.</param>
        /// <param name="rotation">Rotation angle.</param>
        /// <param name="origin">Rotation origin.</param>
        /// <param name="textureSize">In MonoGame origin is relative to source texture size, not dest rect. 
        /// So this param specify source texture size.</param>
        /// <returns>Rotated rectangle bounding box.</returns>
        public static Rectangle GetRotatedBoundingBox(Rectangle rect, float rotation, Vector2 origin, Rectangle textureSize)
        {
            // fix origin to be relative to rect location + fix it to be relative to rect size rather then texture size
            var originSize = ((origin / textureSize.Size.ToVector2()) * rect.Size.ToVector2());
            var convertedOrigin = rect.Location.ToVector2() + originSize;
            // calculate top-left rotated corner
            var topLeft = RotateAround(rect.Location.ToVector2(), convertedOrigin, rotation);
            // calculate rest of rotated corners
            Vector2[] corners = new Vector2[] {
                RotateAround(new Vector2(rect.Left, rect.Bottom), convertedOrigin, rotation),
                RotateAround(new Vector2(rect.Right, rect.Bottom), convertedOrigin, rotation),
                RotateAround(new Vector2(rect.Right, rect.Top), convertedOrigin, rotation)
            };
            // find min and max points
            Vector2 min, max;
            min = max = topLeft;
            foreach (var corner in corners)
            {
                if (corner.X < min.X) min.X = corner.X;
                if (corner.Y < min.Y) min.Y = corner.Y;
                if (corner.X > max.X) max.X = corner.X;
                if (corner.Y > max.Y) max.Y = corner.Y;
            }
            // create rectangle from min-max and return it
            return new Rectangle(min.ToPoint() - originSize.ToPoint(), (max - min).ToPoint());
        }
