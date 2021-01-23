    public struct Grade
    {
        public static readonly double MinValue = 2.0;
        public static readonly double MaxValue = 6.0;
        
        private double value;
       
        public static explicit operator double(Grade grade)
        {
            return grade.value + MinValue;
        }
        public static explicit operator Grade(double gradeValue)
        {
            if (gradeValue < MinValue || gradeValue > MaxValue)
                throw new ArgumentOutOfRangeException("gradeValue", "Grade must be between 2.0 and 6.0");
            return new Grade{ value = gradeValue - MinValue };
        }
    }
