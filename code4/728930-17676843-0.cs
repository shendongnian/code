    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 12)]
    public struct Vector3 : IFormattable
    {
        /// <summary>
        /// The X coordinate.
        /// </summary>
        public float X;
        /// <summary>
        /// The Y coordinate.
        /// </summary>
        public float Y;
        /// <summary>
        /// The Z coordinate.
        /// </summary>
        public float Z;
        /// <summary>
        /// Initializes a new <see cref="Vector3"/> instance.
        /// </summary>
        /// <param name="x">The X coordinate.</param>
        /// <param name="y">The Y coordinate.</param>
        /// <param name="z">The Z coordinate.</param>
        public Vector3(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }
    }
