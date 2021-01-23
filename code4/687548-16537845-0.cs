            private void ResultsGridView_OnItemClick(object sender, ItemClickEventArgs e)
        {
            selectAgence = selectAgences.Last();
            Messenger.Default.Send<Agence>(selectAgence, "1");
       
            this.Frame.Navigate(typeof(MainPage));
        }
