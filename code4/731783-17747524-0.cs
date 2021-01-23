        private void SearchCriteria_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (NeedsToDelete == true)
            {
                SearchCriteria.Text = DelLast;
                NeedsToDelete = false;
                SearchCriteria.Select(SearchCriteria.Text.Length, 0);
            }
        }
