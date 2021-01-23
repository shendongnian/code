    private void btnNewMovie_Click(object sender, EventArgs e)
    {
        using (var movieForm = new MovieForm())
        {
            movieForm.Closing += (sender, args) =>
                {
                    if (movieForm.DialogResult == DialogResult.OK)
                    {
                        if (!movieManager.GetMovieFromList(index).Split(',')  [0].Equals(movieForm.GetTitle))
                        {
                            movieManager.AddNewMovieToMediaLibrary(movieForm.GetNewMovie); // Anropar properties i objektet movieManager
                            UppdateListboxOfMovies(); 
                        }
                        else
                        {
                            MessageBox.Show("Det finns redan en film med titeln " + movieManager.GetMovieFromList(index).Split(',')[0], "Ooops!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            // Prevent the form from closing and let the user try again
                            args.Cancel = true;
                    }
                };
    
            movieForm.ShowDialog();
        }
    }
