    using System;
    using System.ComponentModel.DataAnnotations;
    namespace Test
    {
       [AttributeUsage(AttributeTargets.Property)]
       public class DateGreaterThanAttribute : ValidationAttribute
       {
          public DateGreaterThanAttribute(string dateToCompareToFieldName)
          {
              DateToCompareToFieldName = dateToCompareToFieldName;
          }
           private string DateToCompareToFieldName { get; set; }
           protected override ValidationResult IsValid(object value, ValidationContext validationContext)
           {
               DateTime earlierDate = (DateTime)value;
               DateTime laterDate = (DateTime)validationContext.ObjectType.GetProperty(DateToCompareToFieldName).GetValue(validationContext.ObjectInstance, null);
               if (laterDate > earlierDate)
               {
                   return ValidationResult.Success;
               }
               else
               {
                   return new ValidationResult("Date is not later");
               }
           }
       }
       public class TestClass
       {
           [DateGreaterThan("ReturnDate")]
           public DateTime RentDate { get; set; }
           public DateTime ReturnDate { get; set; }
       }
    }
