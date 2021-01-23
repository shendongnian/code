                            Dictionary<TwoUintsKeyInfo,object> test = new Dictionary<TwoUintsKeyInfo, object>();
            test.Add(new TwoUintsKeyInfo { IdOne = 3, IdTwo = 9 }, new object());
            test.Add(new TwoUintsKeyInfo { IdOne = 10, IdTwo = 15 }, new object());
            uint newStartPoint1 = 1,newEndPoint1=2;
            bool mayUse = (from result in test 
                                let newStartPointIsBetweenStartAndEnd = newStartPoint1.Between(result.Key.IdOne,result.Key.IdTwo)
                                let newEndPointIsBetweenStartAndEnd = newEndPoint1.Between(result.Key.IdOne,result.Key.IdTwo)
                                let completeOverlap = result.Key.IdOne < newStartPoint1 && result.Key.IdTwo > newEndPoint1
                                let FoundOne = 1
                                where newStartPointIsBetweenStartAndEnd || newEndPointIsBetweenStartAndEnd || completeOverlap
                                select FoundOne).Sum()==0;
