        /// <summary>
        /// Implemented - Returns the point coordinates related to a new coordinate system
        /// Does not change original point
        /// </summary>
        /// <param name="Point">Point to be returned in new coordinate system</param>
        /// <param name="NewSystemCouterClockRotation">CounterClokWise Angle of rotation of the new coordinate system compared to the current, measured in radians</param>
        /// <param name="NewSystemOrigin">Location of the new origin point in the current coordinate system</param>
        /// <returns></returns>
        public double[] ChangeCoordinateSystem(double[] Point, double NewSystemCouterClockRotation, double[] NewSystemOrigin)
        {
            //first adjust: fix that winform downwards increasing Y before applying the method
            Point[1] = -Point[1];
            NewSystemOrigin[1] = -NewSystemOrigin[1]
            //end of first adjust
            //original method
            double[] Displacement = new double[2] { Point[0] - NewSystemOrigin[0], Point[1] - NewSystemOrigin[1] };
            double[] Result = new double[2]
            {
                + Displacement[0] * Math.Cos(NewSystemCouterClockRotation) + Displacement[1] * Math.Sin(NewSystemCouterClockRotation), 
                - Displacement[0] * Math.Sin(NewSystemCouterClockRotation) + Displacement[1] * Math.Cos(NewSystemCouterClockRotation) 
            }; 
            //second adjust: reset Y of the result
            Result[1] = - Result[1];
            return Result;
        }
