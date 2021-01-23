        public JsonResult ItemCapacityList(string itemCategoryId)
        {
            List<ItemCapacity> lsItemCapacity = new List<ItemCapacity>();
            string[] itemCategory = itemCategoryId.Split('#');
            int itemCategoryLength = itemCategory.Length, rowCount = 0;
            string itemCategoryIds = string.Empty;
            for (rowCount = 0; rowCount < itemCategoryLength; rowCount++)
            {
                itemCategoryIds += "'" + itemCategory[rowCount].Trim() + "',";
            }
            itemCategoryIds = itemCategoryIds.Remove(itemCategoryIds.Length - 1);
            lsItemCapacity = salesDal.ReadItemCapacityByCategoryId(itemCategoryIds);
            return new JsonResult { Data = lsItemCapacity };
        }
