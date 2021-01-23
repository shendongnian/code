        private static void CompareValues(string k, Dictionary<string, string> propertyMap, TData sourceDal, TEntity entity)
        {
            string sourceField = k;
            string destField = propertyMap[k];
            object sourceval = sourceDal.GetType().GetProperty(sourceField).GetValue(sourceDal, null);
            string sSource = sourceval.ToString();
            object destval = entity.GetType().GetProperty(destField).GetValue(entity, null);
            string sDest = destval.ToString();
            Assert.AreEqual(sSource,
                            sDest,
                            String.Format("Values not equal on fields {0} ({1}) to {2} ({3})",
                                          sourceDal.GetType().GetProperty(sourceField).Name, sourceDal.GetType().GetProperty(sourceField).PropertyType,
                                          entity.GetType().GetProperty(destField).Name, entity.GetType().GetProperty(destField).PropertyType)
                );
        }
