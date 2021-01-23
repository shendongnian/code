        private static void LoadFruits(string Fruit, Dictionary<string, int> FruitDictionary)
        {
            if (FruitDictionary.ContainsKey(Fruit))
                FruitDictionary[Fruit] = FruitDictionary[Fruit] + 1;
            else
                FruitDictionary.Add(Fruit, 1);
        }
        private static bool HasFruit(string Fruit, Dictionary<string, int> FruitDictionary)
        {
            if (FruitDictionary.ContainsKey(Fruit) && FruitDictionary[Fruit] > 0)
            {
                FruitDictionary[Fruit] = FruitDictionary[Fruit] - 1;
                return true;
            }
            return false;
        }
            ...
            List<string> AllThefruits = new List<string>(){"banana" ,"banana","cherry","kiwi","strawberry"};
            Dictionary<string, int> FruitsDictionary = new Dictionary<string, int>();
            List<string> Combination1 = new List<string>() { "banana", "strawberry" }; 
            AllThefruits.ForEach(x => LoadFruits(x, FruitsDictionary));
            bool TestCombination1 = Combination1.All(x => HasFruit(x, FruitsDictionary)); //true
            FruitsDictionary.Clear();
            List<string> Combination2 = new List<string>() { "strawberry" };
            AllThefruits.ForEach(x => LoadFruits(x, FruitsDictionary));
            bool TestCombination2 = Combination2.All(x => HasFruit(x, FruitsDictionary)); //true
            FruitsDictionary.Clear();
            List<string> Combination3 = new List<string>() { "banana", "banana", "banana" };
            AllThefruits.ForEach(x => LoadFruits(x, FruitsDictionary));
            bool TestCombination3 = Combination3.All(x => HasFruit(x, FruitsDictionary)); //false
            FruitsDictionary.Clear();
            List<string> Combination4 = new List<string>() { "banana", "banana" };
            AllThefruits.ForEach(x => LoadFruits(x, FruitsDictionary));
            bool TestCombination4 = Combination4.All(x => HasFruit(x, FruitsDictionary)); //true
