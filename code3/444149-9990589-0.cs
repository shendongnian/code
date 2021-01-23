    public static IEnumerable<Asset> SelectRelevantAssets(this Item item)
    {
         var assetsInItemFound = false;
         foreach (var asset in item.Assets)
         {
             if (HasRelevantAsset(asset))
             {
                 assetsInItemFound = true;
                 yield return asset;
             }
         }
         if (!assetsInItemFound)
         {
             yield break;
         }
         else
         {
             foreach (var subItem in item.SubItems)         
                 foreach (var asset in subItem.Assets)
                    if (HasRelevantAsset(asset))
                        yield return asset;
         }
    }
