        private void lstExams_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                Model.ExamTitles data = (sender as ListBox).SelectedItem as Model.ExamTitles;
               }
         }
