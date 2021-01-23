      var list = input.Split(new[] { "==", "!=", "&&", "||" }, 
                StringSplitOptions.RemoveEmptyEntries);
            var list2 = Enumerable.Range(0, list.Length/2)
                .Select(i => list.ElementAt(i*2).Trim());
            var result = list2.Select(s => s.Substring(1, s.Length - 2));
