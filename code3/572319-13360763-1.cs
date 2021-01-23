        public DateTime(long ticks, DateTimeKind kind) {
            // Error checking omitted
            //...
            this.dateData = ((UInt64)ticks | ((UInt64)kind << KindShift));
        }
