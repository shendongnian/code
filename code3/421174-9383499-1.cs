            Regex r = new Regex(@"(?<FieldName>\w+:)*(?:(?<Value>(?:[^:;]+);)+)");
            var matches = r.Matches("Field1:abc;def;Field2:asd;fgh;moo;"); // Modified to test "uneven" data as well.
            var tuples = new[] { new { FieldName = "", Value = "", Index = 0 } }.ToList(); tuples.Clear();
            foreach (Match match in matches)
            {
                var matchGroups = match.Groups;
                var fieldName = matchGroups[1].Captures[0].Value;
                int index = 0;
                foreach (Capture cap in matchGroups[2].Captures)
                {
                    var tuple = new { FieldName = fieldName, Value = cap.Value, Index = index };
                    tuples.Add(tuple);
                    index++;
                }
            }
            var maxIndex = tuples.Max(tup => tup.Index);
            var jsonItemList = new List<string>();
            for (int a = 0; a < maxIndex+1; a++)
            {
                var jsonBuilder = new StringBuilder();
                jsonBuilder.Append("{");
                
                foreach (var tuple in tuples.Where(tup => tup.Index == a))
                {
                    jsonBuilder.Append(string.Format("\"{0}\":\"{1}\",", tuple.FieldName, tuple.Value));
                }
                jsonBuilder.Remove(jsonBuilder.Length - 1, 1); // trim last comma.
                jsonBuilder.Append("}");
                jsonItemList.Add(jsonBuilder.ToString());
            }
            foreach (var item in jsonItemList)
            {
                // Write your items to your document stream.
            }
