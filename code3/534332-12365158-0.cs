    class CustomizableKeyBinding : KeyBinding
    {
        public CustomizableKeyBinding()
            : base()
        {
        }
        StringToKeyGestureConverter converter = new StringToKeyGestureConverter();
        public string Description
        {
            set
            {
                InitBindings(value);
            }
        }
        private void InitBindings(string value)
        {
            BindingOperations.SetBinding(this, KeyBinding.KeyProperty, new KeyboardShortcutExtension(value) { Converter = converter, ConverterParameter = "Key" });
            BindingOperations.SetBinding(this, KeyBinding.ModifiersProperty, new KeyboardShortcutExtension(value) { Converter = converter, ConverterParameter = "Modifiers" });
        }
    }
