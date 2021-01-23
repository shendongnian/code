    Expression<Func<Crop, bool>> chooseOranges = crop => crop.IsOrange;  
    Expression<Func<Farm, bool>> selectFarm = farm => farm.HasCows;  
    IQueryable farmQuery = GetQuery();
    farmQuery = farmQuery.Where(selectFarm);
    farmQuery = farmQuery.Where(farm => farm.Crops.Any(chooseOranges); 
