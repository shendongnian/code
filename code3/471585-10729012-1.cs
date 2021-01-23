    using System;
    using System.Globalization;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    
    namespace WpfApplication
    {
        internal sealed class ProposedValueErrorValidationRule : ValidationRule
        {
            private readonly DependencyObject targetObject;
            private readonly DependencyProperty targetProperty;
    
            public ProposedValueErrorValidationRule(DependencyObject targetObject, DependencyProperty targetProperty)
                : base(ValidationStep.RawProposedValue, true)
            {
                if (targetObject == null)
                    throw new ArgumentNullException("targetObject");
                if (targetProperty == null)
                    throw new ArgumentNullException("targetProperty");
    
                this.targetObject = targetObject;
                this.targetProperty = targetProperty;
            }
    
            public override ValidationResult Validate(object value, CultureInfo cultureInfo)
            {
                var expression = BindingOperations.GetBindingExpression(this.targetObject, this.targetProperty);
                if (expression != null)
                {
                    var sourceItem = expression.DataItem as IProposedValueErrorInfo;
                    if (sourceItem != null)
                    {
                        var propertyName = expression.ParentBinding.Path != null ? expression.ParentBinding.Path.Path : null;
                        if (propertyName != null)
                        {
                            var error = sourceItem.GetError(propertyName, value, cultureInfo);
                            if (error != null)
                                return new ValidationResult(false, error);
                        }
                    }
                }
                return ValidationResult.ValidResult;
            }
        }
    }
