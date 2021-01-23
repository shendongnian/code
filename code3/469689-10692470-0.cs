    // calculation common interface
    public interface IPriceCalculation 
    {
       public InsurancePrice CalculatePrice(CarData data);   
    }
    
    // result from the calculation
    public class InsurancePrice
    {
       public string Description { get; set; }
       public decimal Price { get; set; }      
    }
    
    
    // concrete implementations 
    public class BrandDealerYearlyPaymentCalculation : IPriceCalculation
    {
       public InsurancePrice CalculatePrice(CarData data)
       {
          // logic to perform calculation of BrandDealer = true, MonthPayment = false
       }
    }
    
    public class BrandDealerMonthlyPaymentCalculation : IPriceCalculation
    {
       public InsurancePrice CalculatePrice(CarData data)
       {
          // logic to perform calculation of BrandDealer = true, MonthPayment = true
          
          // just for example...
          return new InsurancePrice() 
          { 
             Description = "Policy price with a Brand dealer and monthly payments",
             Price = 250.25;
          };
       }
    }
    
    public class NonBrandDealerYearlyCalculation : IPriceCalculation
    {
       public InsurancePrice CalculatePrice(CarData data)
       {
          // logic to perform calculation of BrandDealer = false, MonthPayment = false
       }
    }
    
    public class NonBrandDealerMonthlyCalculation : IPriceCalculation
    {
       public InsurancePrice CalculatePrice(CarData data)
       {
          // logic to perform calculation of BrandDealer = false, MonthPayment = true
       }
    }
