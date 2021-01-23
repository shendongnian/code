        private void ListMediaByType(List<Media> data, Media.MediaType type)
        {
            foreach (Media media in data.Where(media => media.TypeOfMedia == type))
                Console.WriteLine(media.Title);
        }
