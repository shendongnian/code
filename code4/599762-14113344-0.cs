    petsList.GroupBy(
        pet => Math.Floor(pet.Age), // keySelector
        (age, pets) => new          // resultSelector
        {
            Key = age,
            Count = pets.Count(),
            Min = pets.Min(pet => pet.Age),
            Max = pets.Max(pet => pet.Age)
        });
