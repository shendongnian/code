    public class TextBoxExt : TextBox
      {
        static TextBoxExt()
        {
          TextProperty.OverrideMetadata(
            typeof (TextBoxExt),
            new FrameworkPropertyMetadata(default(string))
              {
                DefaultUpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
              });
        }
      }
