    var query = petsList.GroupBy(
        pet => Math.Floor(pet.Age), // keySelector
        pet => pet,             // elementSelector
        (baseAge, ages) => new      // resultSelector
        {
            Key = baseAge,
            Count = ages.Count(),
            Min = ages.Min(pet => pet.Age),
            Max = ages.Max(pet => pet.Age)
        });
