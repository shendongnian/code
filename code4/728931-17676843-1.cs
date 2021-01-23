    /// <summary>
    /// 
    /// </summary>
    public class SphericalObstacle
    {
        private readonly float _radius;
        private readonly Vector3 _center;
        private readonly ulong _vehicleId;
        /// <summary>
        /// Initializes a new instance of the <see cref="SphericalObstacle"/> class.
        /// </summary>
        /// <param name="center">The center.</param>
        /// <param name="radius">The radius.</param>
        /// <param name="parentVehicleId">The parent vehicle id.</param>
        public SphericalObstacle(Vector3 center, float radius, ulong parentVehicleId)
        {
            _radius = radius;
            _center = center;
            _vehicleId = parentVehicleId;
        }
        /// <summary>Gets the vehicle id.</summary>
        public ulong VehicleId { get { return _vehicleId; } }
        /// <summary>Gets the radius.</summary>
        public float Radius { get { return _radius; } }
        /// <summary>Gets the center.</summary>
        public Vector3 Center { get { return _center; } }
        /// <summary>
        /// Checks for sphere collision.
        /// </summary>
        /// <param name="obstacle">The obstacle.</param>
        /// <param name="tolerance">The tolerance.</param>
        /// <returns>
        ///   <c>true</c> if it collides, <c>false</c> otherwise.
        /// </returns>
        public bool CollidesWith(SphericalObstacle obstacle, double tolerance = 0.0d)
        {
            Vector3 difference = Center - obstacle.Center;
            double distance =
                System.Math.Sqrt(System.Math.Pow(difference.X, 2) + System.Math.Pow(difference.Y, 2) + System.Math.Pow(difference.Z, 2));
            double sumRadius = Radius + obstacle.Radius;
            return distance < (sumRadius + tolerance);
        }
        public override string ToString()
        {
            return string.Format("Radius: {0}, Center: {1}", _radius, _center);
        }
    }
