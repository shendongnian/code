    public class TextBoxExt : TextBox
    {
        private static readonly MethodInfo onTextPropertyChangedMethod 
          = typeof(TextBox).GetMethod("OnTextPropertyChanged", BindingFlags.Static | BindingFlags.NonPublic);
        private static readonly MethodInfo coerceTextMethod 
          = typeof(TextBox).GetMethod("CoerceText", BindingFlags.Static | BindingFlags.NonPublic);
        static TextBoxExt()
        {
          
          TextProperty.OverrideMetadata(
            typeof(TextBoxExt),
            // found this metadata with reflector:
            new FrameworkPropertyMetadata(string.Empty,
                                          FrameworkPropertyMetadataOptions.BindsTwoWayByDefault | FrameworkPropertyMetadataOptions.Journal,
                                          new PropertyChangedCallback(MyOnTextPropertyChanged),callback
                                          new CoerceValueCallback(MyCoerceText),
                                          true, // IsAnimationProhibited
                                          UpdateSourceTrigger.PropertyChanged)
            );
        }
        private static object MyCoerceText(DependencyObject d, object basevalue)
        {
          return coerceTextMethod.Invoke(null, new object[] { d, basevalue });
        }
    
        private static void MyOnTextPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
          onTextPropertyChangedMethod.Invoke(null, new object[] { d, e });
        }
      }
