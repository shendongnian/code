        private void ItemsGridView_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (TextBlock element in this.myGridView.GetDescendantsOfType<TextBlock>())
            {
                if(element.Tag != null && element.Tag.Equals("itemCountBlock")){
                    element.Text = "Finally solved!";
                }
            }
        }
