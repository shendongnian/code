            // switching element for better fill
            List<List<Int32>> unfilledlist = listResult.Where(l => l.Sum() < MaxStack).ToList();
            // truncate original result
            unfilledlist.ForEach(l => listResult.Remove(l));
            while (unfilledlist != null && unfilledlist.Count > 1)
            {
                List<Int32> list = unfilledlist.First();
                unfilledlist.Remove(list);
                foreach (Int32 element in list)
                {
                    Int32 needed = MaxStack - list.Sum() + element;
                    Boolean isFound = false;
                    foreach (List<Int32> smallerlist in unfilledlist)
                    {
                        List<Int32> switchingList = new List<int>();
                        // searching how to fill what we needed
                        foreach (Int32 e in smallerlist.OrderByDescending(i => i))
                        {
                            if (e + switchingList.Sum() <= needed)
                                switchingList.Add(e);
                        }
                        // we found a possible switch
                        if (switchingList.Sum() == needed)
                        {
                            // moving first element
                            list.Remove(element);
                            smallerlist.Add(element);
                            // moving element
                            switchingList.ForEach(e => { smallerlist.Remove(e); list.Add(e); });
                            isFound = true;
                            break;
                        }
                    }
                    if (isFound)
                        break;
                }
                listResult.Add(list.OrderByDescending(i => i).ToList());
            }
            // completing result with lists that are not with sum 180
            unfilledlist.ForEach(l => listResult.Add(l.OrderByDescending(i => i).ToList()));
