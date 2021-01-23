        public void Group()
        {
            List<Tuple<int, int>> SongRelations = new List<Tuple<int, int>>();
            SongRelations.Add(new Tuple<int, int>(1, 1));
            SongRelations.Add(new Tuple<int, int>(1, 4));
            SongRelations.Add(new Tuple<int, int>(1, 12));
            SongRelations.Add(new Tuple<int, int>(2, 95));
            var list = SongRelations.GroupBy(s => s.Item1)
                                    .Select(r => new SongsForUser()
                                    {
                                        UserId = r.Key,
                                        Songs = r.Select(t => t.Item2).ToList(),
                                    });
        }
