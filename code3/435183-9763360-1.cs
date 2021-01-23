		private static void FindDupes(IEnumerable<XElement> elements)
		{
			foreach (var element in elements)
			{
				var subElements = element.Descendants();
				var subElementsWithIds = subElements.Where(x => x.Attribute("Id") != null).ToList();
				var ids = subElementsWithIds.Select(x => x.Attribute("Id")).ToList();
				var duplicates = ids.GroupBy(s => s.Value).SelectMany(grp => grp.Skip(1)).Distinct().ToList();
				if (duplicates != null)
				{
					_duplicateLeafs.AddRange(duplicates);
				}
				FindDupes(subElements);
			}
		}
