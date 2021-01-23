    var temp_list = new List<Genre>();
    // new genre { Name = "Rock" , Description = "Rock music" }
    var temp_genre_1 = new Genre();
    temp_genre_1.Name = "Rock";
    temp_genre_1.Description = "Rock music";
    temp_list.Add(temp_genre_1);
    // new genre { Name = "Classic" , Description = "Middle ages music" }
    var temp_genre_2 = new Genre();
    temp_genre_2.Name = "Classic";
    temp_genre_2.Description = "Middle ages music";
    temp_list.Add(temp_genre_2);
    // set genre to the result of your Collection Initializer
    var genre = temp_list;
