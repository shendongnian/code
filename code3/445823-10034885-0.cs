    if (this.dataGridView1.SelectedRows.Count > 0)
        {
            string queryString = "SELECT movieID, Title, MovieYear, Country,Located, Description, Poster, Actors, FilmDirector, Type FROM Movie,movieType WHERE movietype.typeID = Movie.typeID";
            foreach (DataGridViewRow dgvrCurrent in dataGridView1.SelectedRows)
            {
                 int currentRow = int.Parse(dataGridView1.CurrentCell.RowIndex.ToString());
                try
                {
                    string movieIDString = dataGridView1[0, currentRow].Value.ToString();
                    movieIDInt = int.Parse(movieIDString);                
                    string queryDeleteString = "DELETE FROM Movie where movieID = " + movieIDInt + ";";
                    OleDbCommand sqlDelete = new OleDbCommand();
                    sqlDelete.CommandText = queryDeleteString;
                    sqlDelete.Connection = database;
                    sqlDelete.ExecuteNonQuery();                    
                 }
                catch (Exception ex) { }
            }
            loadDataGrid(queryString);
        }
