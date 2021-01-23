    [ServiceContract]
        public interface ICalcPrice
        {
            [OperationContract]
            CalcPrice CalculatePrice(double price);
    
            [OperationContract]
            CalcPrice CalculatePrice(double price, int days);
       
        }
