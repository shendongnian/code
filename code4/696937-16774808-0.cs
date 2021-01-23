	bool valid = str.Replace("MaxUpperLimit", MaxUpperLimit).Split(',').Select(p => p
										 .Split('-')
										 .Select(s=>s.Trim()).ToArray())
                .All(subPart => {
						int i1, i2;
						return (subPart.Length == 1 && int.TryParse(subPart[0], out i1) && i1 <= MaxUpperLimit) 
						|| (subPart.Length == 2 
								&& int.TryParse(subPart[0], out i1) && i1 < MaxUpperLimit 
								&& int.TryParse(subPart[1], out i2) && i2 <= MaxUpperLimit 
								&& i1 < i2);
					});
