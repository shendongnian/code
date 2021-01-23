    public void RemoveFromFavorites(IEnumerable<FavoriteProgram> programs) {
      FavoriteController.RemoveFromFavorites(programs);
      
      UpdateUi();
      SelectedItem = FavoritesList.FirstOrDefault(); // selects the first element in list.
    }
