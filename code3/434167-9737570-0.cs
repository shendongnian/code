        [StructLayout(LayoutKind.Sequential)]
        public class EnvelopeStruct {
            public EnvelopeStruct() {
                this.PointsAft = new Coordinates[4];
                // etc..
            }
            public Coordinates[] PointsAft;
            // etc..
        }
