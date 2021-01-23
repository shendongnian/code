    interface IPositionable { Vector3 Position }
    class FollowCamera{
        public IPositionable ObjectToFollow;
        public FollowCamera(Vector3 RelativePosition)
        {
            this.RelativePosition = relativePosition
        }
        public override void Update()
        {
            //Missing lines of code used to determine 
            //the up vector
            Vector3 forward = Target - Position;
            Vector3 right = Vector3.Cross(forward, Vector3.Up);
            Vector3 up = Vector3.Cross(right, forward);
            Position = ObjectToFollow.Position - RelativePosition;
            Target = ObjectToFollow.Position;
 
            this.View = Matrix.CreateLookAt(Position,
                    Target, up);
        }
    }
