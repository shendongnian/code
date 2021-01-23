    $source = @"
    public class SampleClass
    {
        public static int Add(int a, int b)
        {
            return (a + b);
        }
    
        public int Multiply(int a, int b)
        {
            return (a * b);
        }
    }
    "@
   
     Add-Type $source
     $obj = New-Object SampleClass
