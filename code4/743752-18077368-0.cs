            var st = "{op1 == op2, #} && {op3 > op4, 1, 2} && op5 == op6";
            var regex = "{.*?}";
            for (var match = Regex.Match(st, regex); match.Success; match = Regex.Match(st, regex))
            {
                var oldString = match.Value; // {op1 == op2, #} 
                var op = oldString.Split(' ').ToList()[1].Trim(); // == 
                var csv = oldString.Split(',').Select(x => x.Trim()).ToList(); // [0] = "{op1 == op2" [1] = "#}"
                var expression = csv[0].Remove(0,1); // op1 == op2
                csv.RemoveAt(0);
                var extension = "_" + String.Join("_", csv);
                extension = extension.Remove(extension.Length-1); // _#
                var newString = expression.Replace(op, op + extension);
                st = st.Replace(oldString, newString); 
            }
