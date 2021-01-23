    if (e.KeyCode == Keys.Up)
				{
					if (lvTemp.Focused == true)
					{
						var selected = lvTemp.FocusedItem.Index;
						if (selected.Equals(0))
						{
							enableMoveDown();
						}
						else if (selected.Equals(lvCategory.Items.Count - 1))
						{
							enableMoveUp();
						}
						else
						{
							enableMoveUpMoveDown();
						}
					}
				}
				else if (e.KeyCode == Keys.Down)
				{
					if (lvTemp.Focused == true)
					{
						var selected = lvTemp.FocusedItem.Index;
						if (selected.Equals(0))
						{
							enableMoveDown();
						}
						else if (selected.Equals(lvCategory.Items.Count - 1))
						{
							enableMoveUp();
						}
						else
						{
							enableMoveUpMoveDown();
						}
					}
				}
