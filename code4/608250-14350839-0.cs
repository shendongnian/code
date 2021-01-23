    List<RentalCar> tempList = new List<RentalCar>();
    for (int i = rentalList.Count - 1; i >= 0; i--)
    {
        if (!listBoxRental.SelectedIndices.Contains(i))
        {
           tempList.Add(rentalList[i]);
        }
    }
