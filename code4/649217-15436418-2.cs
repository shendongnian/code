    Hotel temp = (from x in  doc.Descendants("Hotel")
                  select new Hotel()
                  {
                    HotelImages = new Collection<string>(
                                      x.Elements("Documents")
                                       .Descendants("Images")
                                       .Select(img => (string)img.Element("URL") ?? "")
                                       .ToList()
                                  )
                  }).First();
