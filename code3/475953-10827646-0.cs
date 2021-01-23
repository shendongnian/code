        public static List<CategoryItem> LoadFromDataSet(DataSet aDS)
        {
            List<CategoryItem> result = new List<CategoryItem>();
            Dictionary<int, CategoryItem> alreadyRead = new Dictionary<int, CategoryItem>();
            foreach (DataRow aRow in aDS.Tables["YourTable"].Rows)
            {
                CategoryItem newItem = new CategoryItem();
                newItem.CategoryID = (int)aRow["ID"];
                newItem.ParentID = (int)aRow["PrntID"];
                newItem.Name = (string)aRow["Title"];
                alreadyRead[newItem.CategoryID] = newItem;
                CategoryItem aParent;
                if (alreadyRead.TryGetValue(newItem.ParentID, out aParent))
                    aParent.AddSubCategory(newItem);
                else
                    result.Add(newItem);
            }
            return result;
        }
