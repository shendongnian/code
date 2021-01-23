    var movies = File.ReadAllLines("@FilePath").Select(line =>
        new Movies
            {
                moviename = line.Trim(),
                cast = Convert.ToInt32(line.Trim()),
                castmember = new string[Convert.ToInt32(line.Trim())]
            });
