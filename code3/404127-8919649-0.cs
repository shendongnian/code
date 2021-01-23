    public class Student
    {
        Random random = new Random(); 
    
        public Student() 
        { 
            int randomLevel=random.Next(1,3); 
            level = (randomLevel % 2 == 0); 
        } 
    
        public bool readingLevel()//this always returns one value for the entire program. 
        { 
            return level; 
        } 
    }
    public class Program
    {
        public static void Main()
        {
            var students = new List<Student>();
            for (int i = 0; i < 10; i++)
                students.Add(new Student());
            //Now you have 10 Students; each Student has its own random number generator
            //The generators were created within microseconds of each other, so they most likely have THE SAME SEED
            //Because they have the same seed, they will generate identical sequences of numbers
            //Each student's reading level is calculated from the first call to .Next(1, 3) on its own RNG.
            //The RNGs have the same seed, so each will return the same value for the first call to .Next(1, 3)
            //Therefore, all students will have the same reading level!
        }
    }
