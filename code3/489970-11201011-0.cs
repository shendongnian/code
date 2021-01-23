    List<Place> listOne = /* whatever */;
    List<Place> listTwo = /* whatever */;
    List<Place> listMerge = listOne.Concat(
                               listTwo.Where(p1 => 
                                   !listOne.Any(p2 => p1.Id == p2.Id)
                               )
                            ).ToList();
