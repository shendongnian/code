            List<Media> results = new List<Media>();
            results.Add(new Media("Movie 1", "John D", Media.MediaType.DVD));
            results.Add(new Media("Movie 2", "John D", Media.MediaType.DVD));
            results.Add(new Media("Movie 3", "SomeOtherDirector", Media.MediaType.Bluray));
            results.Add(new Media("Movie 4", "John D", Media.MediaType.Bluray));
            IEnumerable<Media> listDirectors = from media in results
                                               where media.Director == "John D"
                                               select media;
            foreach (Media media in listDirectors)
                Console.WriteLine(media.Title);
