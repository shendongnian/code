            List = ListAssetDetail.Where( e => 
                (string.IsNullOrEmpty(SelectedAsset) || SelectedAsset.Equals(e.AssetName)) &&
                (string.IsNullOrEmpty(SlectedBroad) || SlectedBroad.Equals(e.BroadcasterName)) &&
                (string.IsNullOrEmpty(SelectedAssetfor) || SelectedAssetfor.Equals(e.AssetFrom)) &&
                (string.IsNullOrEmpty(SelectedGenre) || SelectedGenre.Equals(e.GenreName)) &&
                (string.IsNullOrEmpty(SelectedBoque) || SelectedBoque.Equals(e.Subcategory)) &&
                (string.IsNullOrEmpty(SelectedContentType) || SelectedContentType.Equals(e.AssetFor)));
