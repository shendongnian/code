    interface IFoo
    {
        Task<BigInteger> CalculateFaculty(int value);
    }
    
    public class Foo: IFoo
    {
      public async Task<BigInteger> CalculateFaculty(int value)
      {
        var res =  await AsyncCall();
        return res;
      }
    }
