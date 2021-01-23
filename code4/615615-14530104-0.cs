    var result = from q in query
                 select new BoAsset
                 {
                     AssetId = q.a.AssetID,
                     AssetCustomerId = q.a.AssetCustomerID,
                     StockImage = q.a.StockImage,
                     Description = q.a.Description,
                     DetailedDescription = q.a.DetailedDescription,
                     Author = q.a.Author,
                     FileName = q.Af1.FileName, //was 1
                     FileExtension = q.Af1.FileExtension, //was 1
                     AssetCreateDate = q.a.AssetCreateDate,
                     AssetExpireDate = q.a.AssetExpireDate,
                     AssetActivateDate = q.a.AssetActivateDate,
                     Notes = q.a.Notes,
                     Keywords = q.a.Keywords,
                     Photographer = q.a.Photographer,
                     PhotographerEmail = q.a.PhotographerEmail
                 };
    List<BoAsset> assetList = result.ToList();
