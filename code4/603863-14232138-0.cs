    public interface ITest
    {
        string TestString { get; set; }
        ITest Clone();      
    }
    
    public class Test : ITest 
    {
        string TestString { get; set; }
        ITest Clone() { 
            return new Test() { 
                TestString = this.TestString 
            }; 
        }
    }
