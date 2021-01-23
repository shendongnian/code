        /// <summary>
        /// Called from app.xaml.cs if the user navigates to the DatePickerPage
        /// </summary>
        /// <param name="page">The page.</param>
        public static void DatePickerHook(PhoneApplicationPage page)
        {
            // Somehow modify the text on the top of the page...
            LoopThroughControls(page, (ui => {
                var tb = ui as TextBlock;
                if (tb != null && tb.Name == "HeaderTitle")
                {
                    tb.Text = "<<Local Translation>>";
                }
            }));
        }
        /// <summary>
        /// Applies an action to every element on a page
        /// </summary>
        /// <param name="parent">The parent.</param>
        /// <param name="modifier">The modifier.</param>
        private static void LoopThroughControls(UIElement parent, Action<UIElement> modifier)
        {
            int count = VisualTreeHelper.GetChildrenCount(parent);
            if (count > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    UIElement child = (UIElement)VisualTreeHelper.GetChild(parent, i);
                    modifier(child);
                    LoopThroughControls(child, modifier);
                }
            }
            return;
        }
