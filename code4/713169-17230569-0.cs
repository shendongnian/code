    public static class BindingExtensions
    {
        public static Binding BindTo<TControl, TControlProperty, TModel, TModelProperty>(this TControl control, TModel model, Expression<Func<TControl, TControlProperty>> controlProperty, Expression<Func<TModel, TModelProperty>> modelProperty, string format = null)
            where TControl : Control
        {
            var controlPropertyName = ((MemberExpression)controlProperty.Body).Member.Name;
            var modelPropertyName = ((MemberExpression)modelProperty.Body).Member.Name;
            var formattingEnabled = !string.IsNullOrWhiteSpace(format);
            var binding = control.DataBindings.Add(controlPropertyName, model, modelPropertyName, formattingEnabled, DataSourceUpdateMode.OnPropertyChanged);
            if (formattingEnabled)
            {
                binding.FormatString = format;
            }
            return binding;
        }
    }
