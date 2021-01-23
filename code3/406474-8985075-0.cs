    [TestMethod]
    public void MergeArrays() {
        string[] Input = new[] { 
            "H1, H2, H3, H4",
            "1,2,,4",
            "1,,3,4"
        };
                         
        var header = Input.ElementAt(0) ;
        var aggregation = string.Join(",", Input.Skip(1).Select(ln => ln.Split(',')).Aggregate(new[] { "", "", "", "" }, Agg));
        var result = new string[] { header, aggregation };
        Assert.AreEqual("H1, H2, H3, H4", header);
        Assert.AreEqual("1,2,3,4", aggregation);
            
    }
    private static string[] Agg(string[] aggregation, string[] input) {
        for (var idx = 0; idx < aggregation.GetLength(0); idx++) {
            if (aggregation[idx] == string.Empty &&input[idx] !=  string.Empty){
                aggregation[idx] = input[idx];
            }
        }
        return aggregation;
    }
