    public class NotificationDeliveryTypeModelBinder : DefaultModelBinder
    {
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var value = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
            if (value != null )
            {
                var rawValues = value.RawValue as string[];
                if (rawValues != null)
                {
                    NotificationDeliveryType result;
                    if (Enum.TryParse<NotificationDeliveryType>(string.Join(",", rawValues), out result))
                    {
                        return result;
                    }
                }
            }
            return base.BindModel(controllerContext, bindingContext);
        }
    }
