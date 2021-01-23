    public float rotX { get; set; }
        public float rotY { get; set; }
        public Vector3 position { get; set; }
        public Matrix Transform {
            get {
                return (Matrix.Identity *
                        Matrix.CreateScale(scale) *
                        Matrix.CreateRotationY(MathHelper.Pi) *
                        Rotation *
                        Matrix.CreateTranslation(position));
            }
        }
        public float ShipCurRotation { get { return (rotX + MathHelper.ToRadians(currentRotation)); } }
        public Matrix Rotation { get { return (Matrix.CreateRotationY(ShipCurRotation) * Matrix.CreateRotationX(rotY)); } }
