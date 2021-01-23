    static class ExtensionMethods
    {
         static void change_text_from_different_thread(this TextBox item, string text)
         {
             item.Invoke(new EventHandler(delegate
                 {
                     item.Text = text;
                 }));
         }
    }
