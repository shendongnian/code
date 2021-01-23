    public interface IPayeePayrollRunInitialPayElementData : IPayeePayrollRunPayElementData
    { }
    public interface IPayeePayrollRunPayElementData
    { }
    class Program
    {
        static void Main(string[] args)
        {
            foreach (Type tinterface in typeof(IPayeePayrollRunInitialPayElementData).GetInterfaces())
            {
                Console.WriteLine(tinterface.FullName);
            }
        }
    }
