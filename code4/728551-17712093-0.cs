    class Collision
    {
        #region Declarations
        private Rectangle rectangle1;
        private Rectangle rectangle2;
        private Rectangle collisionZone;
        #endregion
        #region Constructors
        public Collision(Rectangle R1, Rectangle R2)
        {
            rectangle1 = R1;
            rectangle2 = R2;
            if(AreColliding())
            {
                collisionZone = Rectangle.Intersect(rectangle1, rectangle2);
            }
            else
            {
                collisionZone = Rectangle.Empty;
            }
        }
        #endregion
        #region Properties
        /// <summary>
        /// Returns the x-axis value of the top-left corner of R1
        /// </summary>
        public int TopLeftR1X
        {
            get { return rectangle1.X; }
        }
        /// <summary>
        /// Returns the y-axis value of the top-left corner of R1
        /// </summary>
        public int TopLeftR1Y
        {
            get { return rectangle1.Y; }
        }
        /// <summary>
        /// Returns the x-axis value of the top-right corner of R1
        /// </summary>
        public int TopRightR1X
        {
            get { return rectangle1.X + rectangle1.Width; }
        }
        /// <summary>
        /// Returns the y-axis value of the top-right corner of R1
        /// </summary>
        public int TopRightR1Y
        {
            get { return rectangle1.Y; }
        }
        /// <summary>
        /// Returns the x-axis value of the bottom-left corner of R1
        /// </summary>
        public int BottomLeftR1X
        {
            get { return rectangle1.X; }
        }
        /// <summary>
        /// Returns the y-axis value of the bottom-left corner of R1
        /// </summary>
        public int BottomLeftR1Y
        {
            get { return rectangle1.Y + rectangle1.Height; }
        }
        /// <summary>
        /// Returns the x-axis value of the bottom-right corner of R1
        /// </summary>
        public int BottomRightR1X
        {
            get { return rectangle1.X + rectangle1.Width; }
        }
        /// <summary>
        /// Returns the y-axis value of the bottom-right corner of R1
        /// </summary>
        public int BottomRightR1Y
        {
            get { return rectangle1.Y + rectangle1.Height; }
        }
        /// <summary>
        /// Returns the x-axis value of the top-left corner of R2
        /// </summary>
        public int TopLeftR2X
        {
            get { return rectangle2.X; }
        }
        /// <summary>
        /// Returns the y-axis value of the top-left corner of R2
        /// </summary>
        public int TopLeftR2Y
        {
            get { return rectangle2.Y; }
        }
        /// <summary>
        /// Returns the x-axis value of the top-right corner of R2
        /// </summary>
        public int TopRightR2X
        {
            get { return rectangle2.X + rectangle2.Width; }
        }
        /// <summary>
        /// Returns the y-axis value of the top-right corner of R2
        /// </summary>
        public int TopRightR2Y
        {
            get { return rectangle2.Y; }
        }
        /// <summary>
        /// Returns the x-axis value of the bottom-left corner of R2
        /// </summary>
        public int BottomLeftR2X
        {
            get { return rectangle2.X; }
        }
        /// <summary>
        /// Returns the y-axis value of the bottom-left corner of R2
        /// </summary>
        public int BottomLeftR2Y
        {
            get { return rectangle2.Y + rectangle2.Height; }
        }
        /// <summary>
        /// Returns the x-axis value of the bottom-right corner of R2
        /// </summary>
        public int BottomRightR2X
        {
            get { return rectangle2.X + rectangle2.Width; }
        }
        /// <summary>
        /// Returns the y-axis value of the bottom-right corner of R2
        /// </summary>
        public int BottomRightR2Y
        {
            get { return rectangle2.Y + rectangle2.Height; }
        }
        /// <summary>
        /// Returns the rectangle formed by how much the rectangles overlap.
        /// </summary>
        public Rectangle Overlap
        {
            get { return collisionZone; }
        }
        #endregion
        #region Methods
        public bool AreColliding()
        {
            if (rectangle1.Intersects(rectangle2))
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }
        public Vector2 StopOnCollision(Vector2 position, Vector2 moveDir, int currentspeed)
        {
            if (Overlap.Width < Overlap.Height)
            {
                if (position.X < rectangle2.Left)
                {
                    if (moveDir.X > 0) //Moving Right
                    {
                        moveDir = Vector2.Zero;
                    }
                    else
                    {
                        moveDir.X = -currentspeed;
                        moveDir.Y = 0;
                    }
                }
                //else if ((position.X + 33) > rectangle2.Right)
                else if (position.X < rectangle2.Right)
                {
                    if (moveDir.X < 0) //Moving Left
                    {
                        moveDir = Vector2.Zero;
                    }
                    else
                    {
                        moveDir.X = currentspeed;
                        moveDir.Y = 0;
                    }
                }
            }
            else
            {
                if (Overlap.Y == rectangle2.Top)
                
                {
                    if (moveDir.Y > 0) //Moving Down
                    {
                        moveDir = Vector2.Zero;
                    }
                    else
                    {
                        moveDir.Y = -currentspeed;
                        moveDir.X = 0;
                    }
                }
                else
                {
                    if (moveDir.Y < 0) //Moving Up
                    {
                        moveDir = Vector2.Zero;
                    }
                    else
                    {
                        moveDir.Y = currentspeed;
                        moveDir.X = 0;
                    }
                }
            }
            
            return moveDir;
        }
        #endregion
    }
