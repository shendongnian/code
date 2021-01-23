    [TestMethod]
    public void LinqVersion() {
        Dictionary<int, List<ListItem>> found = new Dictionary<int, List<ListItem>>();
        var actual = Input.GroupBy(lstItem => lstItem.ListId).Where(grp => grp.Count() == 4).SelectMany(grp => grp);
        Assert.IsTrue(Expected.SequenceEqual(actual, new ListItemEqualityComparer()));
    }
    [TestMethod]
    public void NoLinqVersion() {
        Dictionary<int, List<ListItem>> found = new Dictionary<int, List<ListItem>>();
        foreach (var listItem in Input) {
          AddItem(found, listItem.ListId, listItem);
         }
        var actual = new List<ListItem>();
        foreach (var pair in found) {
           if (pair.Value.Count == 4) {
               actual.AddRange(pair.Value);
           }
        }
        Assert.IsTrue(Expected.SequenceEqual(actual, new ListItemEqualityComparer()));
    }
        private static void AddItem(IDictionary<int, List<ListItem>> dictionary, int listId, ListItem listItem) {
            if (!dictionary.ContainsKey(listId)) {
                dictionary.Add(listId, new List<ListItem>());
            }
            dictionary[listId].Add(listItem);
        }
        public class ListItem {
            public int ListId { get; set; }
            public int ItemId { get; set; }
        }
        public class ListItemEqualityComparer : IEqualityComparer<ListItem> {
            public bool Equals(ListItem x, ListItem y) {
                return x.ListId == y.ListId && x.ItemId == y.ItemId;
            }
            public int GetHashCode(ListItem obj) {
                return obj.ListId ^ obj.ItemId;
            }
        }
        public List<ListItem> Input = new List<ListItem>(){
            new ListItem{ ListId = 1 , ItemId = 1},
            new ListItem{ ListId = 2 , ItemId = 1},
            new ListItem{ ListId = 2 , ItemId = 2},
            new ListItem{ ListId = 2 , ItemId = 3},
            new ListItem{ ListId = 2 , ItemId = 4},
            new ListItem{ ListId = 3 , ItemId = 1},
            new ListItem{ ListId = 3 , ItemId = 2},
            new ListItem{ ListId = 4 , ItemId = 1},
            new ListItem{ ListId = 4 , ItemId = 2},
            new ListItem{ ListId = 4 , ItemId = 3},
            new ListItem{ ListId = 4 , ItemId = 4},
            new ListItem{ ListId = 5 , ItemId = 1},
            new ListItem{ ListId = 5 , ItemId = 2},
        };
        public List<ListItem> Expected = new List<ListItem>{
            new ListItem{ ListId = 2 , ItemId = 1},
            new ListItem{ ListId = 2 , ItemId = 2},
            new ListItem{ ListId = 2 , ItemId = 3},
            new ListItem{ ListId = 2 , ItemId = 4},
            new ListItem{ ListId = 4 , ItemId = 1},
            new ListItem{ ListId = 4 , ItemId = 2},
            new ListItem{ ListId = 4 , ItemId = 3},
            new ListItem{ ListId = 4 , ItemId = 4}
        };
