    ...
    SqlCommand find = ...
    var words = this.ToEnumerable(find);
    // returns ILookup<char, string>
    var wordDictionary = words.ToLookup(w => w[0]);
    // wordDictionary['a'] gives an IEnumerable<string> for the words starting with a
    
    // if you really want to use a dictionary, do:
    var wordDictionary = works.GroupBy(w => w[0])
        .ToDictionary(g => g.Key, g => g.ToList());
    
    // the ToEnumerable implementation
    private IEnumerable<string> ToEnumerable(SqlCommand find)
    {
        using (var reader = find.ExecuteReader) {
            while (reader.Read()) {
               if (!reader.IsDBNull(0)) { yield return reader[1].ToString(); }
            }
        }
    }
