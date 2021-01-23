    foreach (Room room in this._rooms)
			{
				if (oldFloor.Name == room.Floor.Name)
				{
					foreach (Asset asset in this._assets)
					{
						if (asset.Parent == room)
						{
							asset.Parent = null;
						}
					}
				}
			}
