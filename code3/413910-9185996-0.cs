    ALTER PROCEDURE updateMovieClicks
    (
    @movieTitle varchar(50)
    )
    AS
    update MovieListTable set movieClicks=(movieClicks+1) where movieTitle=@movieTitle;
    
    SqlCommand cmdIncreaseMovieClicks = new SqlCommand("updateMovieClicks", conn);
    cmdIncreaseMovieClicks.CommandType = CommandType.StoredProcedure;
    cmdIncreaseMovieClicks.Parameters.Add("@movieTitle", SqlDbType.nvarchar).Value 
    = session["videoName"].tostring();
    conn.Open();
    cmdIncreaseMovieClicks.ExecuteNonQuery();
    conn.Close();
