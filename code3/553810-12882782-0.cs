    Random random = new Random();
    lstBoxGarage.Add(richcars[random.Next(0,richcars.GetLength(0)),0]);
    for (int i = 0; i < 4; i++)
        {
            var car = cars[random.Next(0,cars.GetLength(0)),0];
            if (lstBoxGarage.Contains(car))
            {
                i--;
            }
            else
            {
                lstBoxGarage.Add(car);
            }
        }
