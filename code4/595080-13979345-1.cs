    List<object[]> olst = new List<object[]>();
    
    			olst.Add(new object[] { "AA1", "X" });
    			olst.Add(new object[] { "AA2", "Y" });
    			olst.Add(new object[] { "AA2", "Y" });
    			olst.Add(new object[] { "AA1", "X" });
    			olst.Add(new object[] { "AA1", "Y" });
    
    			var result = from ol in olst
    						 group ol by new {p1 = ol[0], p2 = ol[1]}
    						 into g
    						 select g.First();
						 
