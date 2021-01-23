        public class NotEqualTo: CompareAttribute
        {
            public NotEqualTo(string otherProperty) : base(otherProperty)
            {
            }
            protected override System.ComponentModel.DataAnnotations.ValidationResult IsValid(object value,
                                                                                              System.ComponentModel.
                                                                                                  DataAnnotations.
                                                                                                  ValidationContext
                                                                                                  validationContext)
            {
                PropertyInfo property = validationContext.ObjectType.GetProperty(this.OtherProperty);
                if (property == (PropertyInfo) null)
                {
                    return
                        new ValidationResult(string.Format((IFormatProvider) CultureInfo.CurrentCulture,
                                                           "Property {0} does not exist", new object[1]
                                                               {
                                                                   (object) this.OtherProperty
                                                               }));
                }
                else
                {
                    object objB = property.GetValue(validationContext.ObjectInstance, (object[]) null);
                    if (object.Equals(value, objB))
                        return new ValidationResult(this.FormatErrorMessage(validationContext.DisplayName));
                    else
                        return (ValidationResult) null;
                }
            }
        }
