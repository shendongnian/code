    public class Pet {
        public string Name { get; set; }
        public string Type { get; set; }
    }
    [TestMethod]
    public void TestMethod1() {
        var pets = new List<Pet>() {
                new Pet{Name= "Bob", Type= "Fish"},
                new Pet{Name= "Rex", Type= "Dog"},
                new Pet{Name= "Alf", Type= "Dog"},
                new Pet{Name= "Fluffy", Type= "Cat"},
                new Pet{Name= "Apollo", Type= "Fish"},
                new Pet{Name= "Mango", Type= "Horse"}
        };
        var expected = new List<string>() {
                "Apollo, Fish",
                "Alf, Dog",
                "Bob, Fish",
                "Fluffy, Cat",
                "Mango, Horse",
                "Rex, Dog",
        };
        var sortedPets = pets.OrderBy(pt => pt, new PetEqualityComparer()).Select(pt => string.Format("{0}, {1}", pt.Name, pt.Type));
        Assert.IsTrue(expected.SequenceEqual(sortedPets));
    }
    public class PetEqualityComparer : IComparer<Pet> {
        readonly static string[] PetTypes = new [] { "Fish", "Horse", "Dog", "Cat" };
        public int Compare(Pet x, Pet y) {
            var xFirst = string.IsNullOrEmpty(x.Name) ? 'A' - 1 : x.Name[0];
            var yFirst = string.IsNullOrEmpty(y.Name) ? 'A' - 1 : y.Name[0];
            if (xFirst != yFirst) {
                    return xFirst.CompareTo(yFirst);
            }
            return GetIndex(x.Type).CompareTo(GetIndex(y.Type));
                
        }
        private int GetIndex(string petType) {
            var ret = -1;
            for (var idx = 0; idx < PetTypes.Length; idx ++ ) {
               if (PetTypes[idx] == petType) {
                   ret = idx;
                   break;
               }
            }
            return ret;
        }
    }
