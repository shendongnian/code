        public static double SSDifference(this Vector3D vectorA, Vector3D vectorB)
        {
            // set vectors to length = 1
            vectorA.Normalize();
            vectorB.Normalize();
            // subtract to get difference vector
            var diff = Vector3D.Subtract(vectorA, vectorB);
            // sum of the squares of the difference (also happens to be difference vector squared)
            return diff.LengthSquared;
        }
