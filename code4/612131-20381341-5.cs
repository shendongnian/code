    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    
    /// This is the base class for all entities and it provide a change notfication.
    public abstract class Entity : INotifyPropertyChanged
    {
      // Event fired when the property is changed!
      public event PropertyChangedEventHandler PropertyChanged;
    
      
      /// Called when int property in the inherited class is changed for ther others properties like (double, long, or other entities etc,) You have to do it.
      protected void HandlePropertyChange(ref int value, int newValue, string propertyName)
      {
        if (value != newValue)
        {
          value = newValue;
          this.Validate(propertyName);
          this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
      }
    
      /// Validate the property 
      /// <returns>
      /// The list of validation errors
      /// </returns>
      private ICollection<ValidationResult> PropertyValidator(string propertyName)
      {
        var validationResults = new Collection<ValidationResult>();
        PropertyDescriptor property = TypeDescriptor.GetProperties(this)[propertyName];
    
        Validator.TryValidateProperty(
          property.GetValue(this),
          new ValidationContext(this, null, null) { MemberName = propertyName },
          validationResults);
    
        return validationResults;
      }
    
      /// Validates the given property and return all found validation errors.
      private void Validate(string propName)
      {
        var validationResults = this.PropertyValidator(propName);
        if (validationResults.Count > 0)
        {
          var validationExceptions = validationResults.Select(validationResult => new ValidationException(validationResult.ErrorMessage));
          var aggregateException = new AggregateException(validationExceptions);
          throw aggregateException;
        }
      }
    }
