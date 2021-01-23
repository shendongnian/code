		var element = XElement.Parse(xml);
		var elementsWithPossibleCCNumbers =
			element.Descendants()
					.Where(d => d.Attributes()
						.Where(a => a.Value.Length >= 13 && a.Value.Length <= 16)
						.Count(a => long.TryParse(a.Value, out numeric)) == 1);
		elementsWithPossibleCCNumbers
			.SelectMany(e => e.Attributes())
			.Where(a => long.TryParse(a.Value, out numeric))
			.ToList()
			.ForEach(a => a.Value = a.Value.Replace(a.Value, MaskNumber(a.Value)));
