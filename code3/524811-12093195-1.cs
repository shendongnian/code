            List<string> AllThefruits = new List<string>(){"banana" ,"banana","cherry","kiwi","strawberry"};
            List<string> Combination1 = new List<string>(){ "banana" , "strawberry" };
            List<string> Combination2 = new List<string>(){"strawberry"};
            List<string> Combination3 = new List<string>() { "banana", "banana", "banana" };
            List<String> TempList = new List<string>();
            TempList.AddRange(AllThefruits);
            
            bool TestCombination1 = Combination1.All
                (
                    x =>
                    {
                        if (TempList.Contains(x))
                        {
                            TempList.Remove(x);
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                );
            TempList.Clear();
            TempList.AddRange(AllThefruits);
            
            bool TestCombination2 = Combination2.All
                (
                    x =>
                    {
                        if (TempList.Contains(x))
                        {
                            TempList.Remove(x);
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                );
            TempList.Clear();
            TempList.AddRange(AllThefruits);
            
            bool TestCombination3 = Combination3.All
                (
                    x =>
                    {
                        if (TempList.Contains(x))
                        {
                            TempList.Remove(x);
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                );
