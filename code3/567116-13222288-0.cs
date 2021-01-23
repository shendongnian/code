                MyObject mo = list.FirstOrDefault(x => x.TheProperty.Equals(SomeValue));
                if(mo != null)
                {
                    int index = list.IndexOf(mo);
                    MyObject moMinus3 = list[(index - 3 + list.Count) % list.Count];
                    MyObject moMinus2 = list[(index - 2 + list.Count) % list.Count];
                    MyObject moMinus1 = list[(index - 1 + list.Count) % list.Count];
                    MyObject mo0 = list[index];
                    MyObject moPlus1 = list[(index + 1 + list.Count) % list.Count];
                    MyObject moPlus2 = list[(index + 2 + list.Count) % list.Count];
                    MyObject moPlus3 = list[(index + 3 + list.Count) % list.Count];
                }
