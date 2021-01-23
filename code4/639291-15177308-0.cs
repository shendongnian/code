     var lastRowUpdated = 0;
            var i = 0;
            if (_assetsavedData.AssetId == -1)
            {
                foreach (var rowItem in from object row in RadGridAssetTable.Items select row as AssetLinked)
                {
                    Debug.WriteLine(rowItem.AssetItems.AssetCommonName);
                    if (rowItem.AssetItems.AssetCommonName.Equals(_assetsavedData.AssetCommonName))
                    {
                        lastRowUpdated = i;
                        Debug.WriteLine("found at " + i);
                        break;
                    }
                    i++;
                }
            }
            else
            {
                lastRowUpdated = RadGridAssetTable.Items.IndexOf(this.RadGridAssetTable.SelectedItem);
            }
