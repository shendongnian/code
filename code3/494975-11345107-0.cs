    namespace ValidationSummary.Models
    {
       using System;
       using System.Collections.Generic;
       using System.ComponentModel.DataAnnotations;
       public class TradeModel : IValidatableObject
       {
          public DateTime StartDate { get; set; }
    
          public DateTime EndDate { get; set; }
        
          public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
          {
             List<ValidationResult> validationResults = new List<ValidationResult>();
             if (EndDate < StartDate)
             {
                validationResults.Add(new ValidationResult("End date must not be before start date"));
             }
         
             return validationResults;
          }
       }
    }
    namespace ValidationSummary.ViewModels
    {
       public class Trade
       {
          public Trade()
          {
             this.TradeModel = new Models.TradeModel();
          }
    
          public Models.TradeModel TradeModel { get; private set; }
       }
    }
