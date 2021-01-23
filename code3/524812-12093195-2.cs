            List<string> AllThefruits = new List<string>(){"banana" ,"banana","cherry","kiwi","strawberry"};
            List<string> Combination1 = new List<string>(){ "banana" , "strawberry" };
            List<string> Combination2 = new List<string>(){"strawberry"};
            List<string> Combination3 = new List<string>() { "banana", "banana", "banana" };
            HashSet<string> TempList = new HashSet<string>();
            
            AllThefruits.ForEach(x => TempList.Add(x));
            bool TestCombination1 = Combination1.All(x => TempList.Remove(x));
            
            TempList.Clear();
            AllThefruits.ForEach(x => TempList.Add(x));
            bool TestCombination2 = Combination2.All(x => TempList.Remove(x));
            
            TempList.Clear();
            AllThefruits.ForEach(x => TempList.Add(x));
            bool TestCombination3 = Combination3.All(x => TempList.Remove(x));
