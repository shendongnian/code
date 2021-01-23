            destinationList.ForEach(x =>
            {
                SourceType newSource = sourceList.Find(s=>s.Id == x.Id);
                if (newSource == null)
                {
                    destinationList.Remove(destinationList.Find(d => d.Id == x.Id));
                }
                else
                {
                    x.Name = newSource.Name;
                }
            });
