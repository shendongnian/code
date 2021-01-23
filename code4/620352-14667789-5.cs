    var filteredList = list.Where(x =>
                {
                    DateTime dt;
                    return DateTime.TryParse(x, out dt);
                }).Select(DateTime.Parse).OrderByDescending(x => x);
