    public class ResourceKeyBindingExtension : MarkupExtension
    {
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            var resourceKeyBinding = new Binding()
            {
                BindsDirectlyToSource = BindsDirectlyToSource,
                Mode = BindingMode.OneWay,
                Path = Path,
                XPath = XPath,
            };
     
            //Binding throws an InvalidOperationException if we try setting all three
            // of the following properties simultaneously: thus make sure we only set one
            if (ElementName != null)
            {
                resourceKeyBinding.ElementName = ElementName;
            }
            else if (RelativeSource != null)
            {
                resourceKeyBinding.RelativeSource = RelativeSource;
            }
            else if (Source != null)
            {
                resourceKeyBinding.Source = Source;
            }
     
            var targetElementBinding = new Binding();
            targetElementBinding.RelativeSource = new RelativeSource()
            {
                Mode = RelativeSourceMode.Self
            };
     
            var multiBinding = new MultiBinding();
            multiBinding.Bindings.Add(targetElementBinding);
            multiBinding.Bindings.Add(resourceKeyBinding);
     
            // If we set the Converter on resourceKeyBinding then, for some reason,
            // MultiBinding wants it to produce a value matching the Target Type of the MultiBinding
            // When it doesn't, it throws a wobbly and passes DependencyProperty.UnsetValue through
            // to our MultiBinding ValueConverter. To circumvent this, we do the value conversion ourselves.
            // See http://social.msdn.microsoft.com/forums/en-US/wpf/thread/af4a19b4-6617-4a25-9a61-ee47f4b67e3b
            multiBinding.Converter = new ResourceKeyToResourceConverter()
            {
                ResourceKeyConverter = Converter,
                ConverterParameter = ConverterParameter,
                StringFormat = StringFormat,
            };
     
            return multiBinding.ProvideValue(serviceProvider);
        }
     
        [DefaultValue("")]
        public PropertyPath Path { get; set; }
     
        // [snipped rather uninteresting declarations for all the other properties]
    }
