    using Microsoft.VisualBasic;
    
    namespace ErrSample
    {
        class Program
        {
            static void Main(string[] args)
            {
                ErrObject err = Information.Err();
    
                // Definitions
                const int PART1_LENGTH = 5;
                string sPart1 = "Some value";
                int vbObjectError = 123;
                double d;
    
                if (sPart1.Length != PART1_LENGTH)
                    err.Raise(vbObjectError, null, "Part 1 must be " + PART1_LENGTH);
                else if (!double.TryParse(sPart1, out d))
                    err.Raise(vbObjectError, null, "Part 1 must be numeric");
            }
        }
    }
