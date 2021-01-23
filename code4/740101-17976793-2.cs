    public class CalculatorLogics
    {
        private double grade;
        private double gradeValue;
        private double calculateGrades;
        private int credits;
        private GPA_Calculator _GPA_Calculator;
        public CalculatorLogics(GPA_Calculator theGPA_Calculator)
        {
            _GPA_Calculator = theGPA_Calculator;
        }
        public double SelectedGrade 
        {
            get { return grade; }
            set { grade = value; }
        }
        public int CourseCredit 
        {
            get { return credits; }
            set { credits = value; }
        }
        public double CalcGrade 
        {
            get 
            {
            return calculateGrades; 
            }
        }
        public void performGpaCalculations() 
        {
            const double grade_A = 4.00;
            const double grade_A_minus = 3.67;
            const double grade_B_plus = 3.33;
            const double grade_B = 3.00;
            const double grade_B_minus = 2.67;
            const double grade_C_plus = 2.33;
            const double grade_C = 2.00;
            const double grade_C_minus = 1.67;
            const double grade_D = 1.33;
            const double grade_F = 0.00;
            switch (_GPA_Calculator.comboBox1.SelectedItem.ToString()) 
            {
                case "A":
                    gradeValue = grade_A;
                    break;
                case "A-":
                    gradeValue = grade_A_minus;
                    break;
                case "B+":
                    gradeValue = grade_B_plus;
                    break;
                case "B":
                    gradeValue = grade_B;
                    break;
                case "B-":
                    gradeValue = grade_B_minus;
                    break;
                case "C+":
                    gradeValue = grade_C_plus;
                    break;
                case "C":
                    gradeValue = grade_C;
                    break;
                case "C-":
                    gradeValue = grade_C_minus;
                    break;
                case "D":
                    gradeValue = grade_D;
                    break;
               case "F":
                    gradeValue = grade_F;
                    break;
            }
            calculateGrades = gradeValue * credits;
        }
    }
