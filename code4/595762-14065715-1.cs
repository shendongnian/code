                private void contactFilterString_TextChanged(object sender, TextChangedEventArgs e)
        {
           // ContactListing();
            SearchVisualTree(ContactList);
            if (contactFilterString.Text == "")
            {
                ContactListing();
            }
        }
        private void SearchVisualTree(Action ContactListing)
        {
            SearchVisualTree(ContactList);
        }
        private void SearchVisualTree(DependencyObject targetElement)
        {
            var count = VisualTreeHelper.GetChildrenCount(targetElement);
            for (int i = 0; i < count; i++)
            {
                var child = VisualTreeHelper.GetChild(targetElement, i);
                if (child is TextBlock)
                {
                    textBlock1 = (TextBlock)child;
                    HighlightText();
                    break;
                }
                else
                {
                    //ContactListing();
                    SearchVisualTree(child);
                }
            }
        }
        private void HighlightText()
        {
            if (textBlock1 != null)
            {
                string text = textBlock1.Text;
                textBlock1.Text = text;
                textBlock1.Inlines.Clear();
                int index = text.IndexOf(contactFilterString.Text);
                int lenth = contactFilterString.Text.Length;
                if (!(index < 0))
                {
                    Run run = new Run() { Text = text.Substring(index, lenth), FontWeight = FontWeights.ExtraBold };
                    run.Foreground = new SolidColorBrush(Colors.Orange);
                    textBlock1.Inlines.Add(new Run() { Text = text.Substring(0, index), FontWeight = FontWeights.Normal });
                    textBlock1.Inlines.Add(run);
                    textBlock1.Inlines.Add(new Run() { Text = text.Substring(index + lenth), FontWeight = FontWeights.Normal });
                    textBlock1.FontSize = 30;
                    textBlock1.Foreground = new SolidColorBrush(Colors.Black);
                }
                else
                {
                    //textBlock1.Text = "No Match";
                }
            }
        }
         /// <summary>
        /// To List all the Contacts. . .
        /// </summary>
        private void ContactListing()
        {
            ContactList.DataContext = null;
            Contacts cons = new Contacts();
            cons.SearchCompleted += new EventHandler<ContactsSearchEventArgs>(Contacts_SearchCompleted);
            cons.SearchAsync(contactFilterString.Text, FilterKind.DisplayName, "Contacts");
        }
        /// <summary>
        /// To Fetch All Contacts from Mobile Contacts. . .
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Contacts_SearchCompleted(object sender, ContactsSearchEventArgs e)
        {
            try
            {
         
                ContactList.DataContext = e.Results;
            }
            catch (Exception)
            {
                throw;
            }
        }
