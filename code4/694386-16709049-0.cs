    //Create a new class
    public class ConreteAdder : IAdder
    {
        public decimal Add(decimal total,decimal payment)
        {
            return total - payment; //What ever method or mathematical solution you want
        }
    }
    public interface IAdder
    {
        decimal Add(float total, float payment);
    }
