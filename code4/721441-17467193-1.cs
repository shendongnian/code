     public interface IData
     {
     }
    
     public class RealData : IData 
     {
     }
    
     IData data = new RealData(); 
     Console.WriteLine(data.GetType());
