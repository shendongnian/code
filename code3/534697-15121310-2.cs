         namespace NameSpaceXy
         {
           public partial class EntryWidget: ITranslateMethod
           {
             public void Translate()
             {
               GtkUtility.SetLabel(TitleLabel, Translator.Translation<EntryWidgetTranslation>().TitleLabel_LabelProp);
               GtkUtility.SetImage(KeyboardImage, Translator.Translation<EntryWidgetTranslation>().KeyboardImage_Pixbuf);
               //..
           }
          }
        }
