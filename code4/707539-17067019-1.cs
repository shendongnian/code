    public class InvestmentCalculator
    {
        pubilc IEnumerable<Stock> CalculateInvestmentValue(IEnumerable<Stock> Stocks)
        {
           foreach (var stock in stocks)
           {
              var itemValue = GetSotckValueFromMarket(stock);
              stock.UpdateValue(itemValue)
              AddProjection(stock);
           }
        }
    
        public decimal GetStockValueFromMarket(Stock stock)
        {
          //Do something
        } 
    
        public decimal AddProjection(Stock stock) 
        {
          //Do something    
        }
    
    }
