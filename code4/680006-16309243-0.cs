        public void AddAsset(string AstName, string AstCondition)
        {
            DataClasses1DataContext context = new DataClasses1DataContext();
            Asset AssetObj = new Asset();
            AssetObj.AstName = AstName;
            AssetObj.AstCondition = AstCondition;
            context.Assets.Add(AssetObj);
            context.SaveChanges();        
        }
