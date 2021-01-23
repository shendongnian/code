        [TestMethod]
        [Description("Dynamic generate lambda expression")]
        
        public void DynamicGenerateMethod1()
        {
            Item item1 = new Item()
                            {
                                ItemID = "test1",
                                AnalyzeData = new ItemAnalyzeData[]
                                                  {
                                                      new ItemAnalyzeData()
                                                          {
                                                              DepartmentIDs = new []{"Department1","Department2"}
                                                          }, 
                                                  }
                            };
            Item item2 = new Item()
            {
                ItemID = "test2",
                AnalyzeData = new ItemAnalyzeData[]
                                                  {
                                                      new ItemAnalyzeData()
                                                          {
                                                              DepartmentIDs = new []{"Department3","Department4"}
                                                          }, 
                                                  }
            };
           
            Expression<Func<Item, bool>> expectedExpression =
                item => item.AnalyzeData.Any(subitem => subitem.DepartmentIDs.Any(subitem2 => subitem2 == "Department3"));
            //Get Enumerable.Any generic method
            var anyPredicate =
                typeof(Enumerable).GetMethods().First(m => m.Name == "Any" && m.GetParameters().Length == 2);
            #region Build inner most lambda expression : subitem2 => subitem2 == "Department3"
            var subitem2Para = Expression.Parameter(typeof(string), "subitem2");
            var subitem2CompareValue = Expression.Equal(subitem2Para, Expression.Constant("Department3", typeof(string)));
            var subitem2CompareFun = Expression.Lambda<Func<string, bool>>(subitem2CompareValue, subitem2Para);
            #endregion
            #region Build center lambda expression : subitem => subitem.DepartmentIDs.Any( ... )
            var subitemPara = Expression.Parameter(typeof(ItemAnalyzeData), "subitem");
            var departmentIDsAnyMethodCall = anyPredicate.MakeGenericMethod(typeof(string));
            var subItemDepartmentIDsCall = Expression.Call(departmentIDsAnyMethodCall, Expression.Property(subitemPara, "DepartmentIDs"), subitem2CompareFun);
            var subitemCompareFun = Expression.Lambda<Func<ItemAnalyzeData, bool>>(subItemDepartmentIDsCall, subitemPara);
            #endregion
            #region Build outer most lambda expression : item => item.AnalyzeData.Any( ... )
            var itemExpr = Expression.Parameter(typeof(Item), "item");
            var analyzeAnyMethodCall = anyPredicate.MakeGenericMethod(typeof(ItemAnalyzeData));
            var itemAnalyzeDataCall = Expression.Call(analyzeAnyMethodCall, Expression.Property(itemExpr, "AnalyzeData"), subitemCompareFun);
            var itemCompareFun = Expression.Lambda<Func<Item, bool>>(itemAnalyzeDataCall, itemExpr);
            #endregion
            
            var method = itemCompareFun.Compile();
            
            var actualLambdaCode = itemCompareFun.ToString();
            var expectLambdaCode = expectedExpression.ToString();
            Assert.AreEqual(expectLambdaCode, actualLambdaCode);
            Assert.IsFalse(method.Invoke(item1));
            Assert.IsTrue(method.Invoke(item2));
            
        }
