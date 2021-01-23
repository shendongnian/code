        private void LoadUi()
        {
            try
            {
                this.IsAdornerVisible = true;
                RefreshCallback();
                ... some long going view initialization...
            }
            finally
            {
                this.IsAdornerVisible = false;
            }
    }
