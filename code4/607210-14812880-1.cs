        public Linqfilter()
        {
            //as Note: I modified a few classes from you because i doesn'T have your Member, Operation, Make,... classes
            #region declaration
            var originalAdCarList = new List<AdCar>() 
            {
                new AdCar(){Id=1017, Title= "Alfa Romeo 145 1.6TDI 2013", Category= new Category(){Id =12}} ,
                new AdCar(){Id=1018, Title= "Alfa Romeo 146 1.6TDI 2013", Category= new Category(){Id =11}} ,
                new AdCar(){Id=1019, Title= "Alfa Romeo 147 1.6TDI 2013", Category= new Category(){Id =12}} 
            };
            var originalKeywordAdCategoryList = new List<KeywordAdCategory>() 
            {
                new KeywordAdCategory() { Keyword_Id=1356, Ad_Id=1017,Category_Id=1},
                new KeywordAdCategory() { Keyword_Id=1356, Ad_Id=1018,Category_Id=1},
                new KeywordAdCategory() { Keyword_Id=1356, Ad_Id=1019,Category_Id=1},
                new KeywordAdCategory() { Keyword_Id=1357, Ad_Id=1017,Category_Id=1},
                new KeywordAdCategory() { Keyword_Id=1357, Ad_Id=1018,Category_Id=1},
                new KeywordAdCategory() { Keyword_Id=1357, Ad_Id=1019,Category_Id=1},
                new KeywordAdCategory() { Keyword_Id=1358, Ad_Id=1017,Category_Id=1},
                new KeywordAdCategory() { Keyword_Id=1373, Ad_Id=1019,Category_Id=1}            
            };
            var originalCategoryList = new List<Category>()
            {
                new Category(){Id=1,    Name="NULL    1   Carros"},
                new Category(){Id=2,    Name="NULL    1   Motos"},
                new Category(){Id=3,    Name="NULL    2   Oficinas"},
                new Category(){Id=4 ,   Name="NULL    2   Stands"},
                new Category(){Id=5 ,   Name="NULL    1   Comerciais"},
                new Category(){Id=8,    Name="NULL    1   Barcos"},
                new Category(){Id=9 ,   Name="NULL    1   Máquinas"},
                new Category(){Id=10 ,  Name="NULL    1   Caravanas e Autocaravanas"},
                new Category(){Id=11 ,  Name="NULL    1   Peças e Acessórios"},
                new Category(){Id=12 ,  Name="1   1   Citadino"},
                new Category(){Id=13 ,  Name="1   1   Utilitário"},
                new Category(){Id=14 ,  Name="1   1   Monovolume"}
            };
            var originalKeywordList = new List<Keyword>() 
            {
                 new Keyword(){Id=1356 ,Name="ALFA"},
                 new Keyword(){Id=1357 ,Name="ROMEO"},
                 new Keyword(){Id=1358 ,Name="145"},
                 new Keyword(){Id=1373 ,Name="147"}
            };
            #endregion declaration
            string searchText = "ALFA";
            // split the string searchText in an Array of substrings
            var splitSearch = searchText.Split(' '); 
            
            var searchKeyList =new List<Keyword>();
            // generate a list of Keyword based on splitSearch
            foreach (string part in splitSearch)
                if(originalKeywordList.Any(key => key.Name == part))
                    searchKeyList.Add(originalKeywordList.First(key => key.Name == part));
            // generate a list of KeywordAdCategory  based on searchKList
            var searchKACList = new List<KeywordAdCategory>();
            foreach(Keyword key in searchKeyList)
                foreach (KeywordAdCategory kAC in originalKeywordAdCategoryList.Where(kac => kac.Keyword_Id == key.Id))
                    searchKACList.Add(kAC);
            var groupedsearchKAClist = from kac in searchKACList group kac by kac.Keyword_Id;
            var listFiltered = new List<AdCar>(originalAdCarList);
            //here starts the real search part
            foreach (IGrouping<int, KeywordAdCategory> kacGroup in groupedsearchKAClist)
            {
                
                var listSingleFiltered = new List<AdCar>();
                //  generate a list of AdCar that matched the current KeywordAdCategory filter
                foreach (KeywordAdCategory kac in kacGroup)
                    foreach (AdCar aCar in originalAdCarList.Where(car => car.Id == kac.Ad_Id))
                        listSingleFiltered.Add(aCar);
                var tempList = new List<AdCar>(listFiltered);
                // iterrates over a temporary copie of listFiltered and removes items which don't match to the current listSingleFiltered
                foreach (AdCar aC in tempList)
                    if (!listSingleFiltered.Any(car => car.Id == aC.Id))
                        listFiltered.Remove(aC);
            }
            var AdCarCount = listFiltered.Count; // is the count of the AdCar who match
            var CatDic =new  Dictionary<Category, int>(); // will contain the Counts foreach Categorie > 0
            foreach(AdCar aCar in listFiltered)
                if(originalCategoryList.Any(cat => cat.Id ==aCar.Category.Id))
                {
                    var selectedCat = originalCategoryList.First(cat => cat.Id == aCar.Category.Id);
                    if (!CatDic.ContainsKey(selectedCat))
                    {
                        CatDic.Add(selectedCat, 1);//new Category Countvalue
                    }
                    else
                    {
                        CatDic[selectedCat]++; //Category Countvalue +1
                    }
                }
        }
    }
    public class Keyword
    {
        // Primary properties
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class Category
    {
        // Primary properties
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class KeywordAdCategory
    {
        //[Key]
        //[Column("Keyword_Id", Order = 0)]
        public int Keyword_Id { get; set; }
        //[Key]
        //[Column("Ad_Id", Order = 1)]
        public int Ad_Id { get; set; }
        //[Key]
        //[Column("Category_Id", Order = 2)]
        public int Category_Id { get; set; }
    }
    public class Ad
    {
        // Primary properties
        public int Id { get; set; }
        public string Title { get; set; }
        public string TitleStandard { get; set; }
        public string Version { get; set; }
        public int Year { get; set; }
        public decimal Price { get; set; }
        // Navigation properties
        public string Member { get; set; }
        public Category Category { get; set; }
        public IList<string> Features { get; set; }
        public IList<int> Pictures { get; set; }
        public IList<string> Operations { get; set; }
    }
    public class AdCar : Ad
    {
        public int Kms { get; set; }
        public string Make { get; set; }
        public int Model { get; set; }
        public int Fuel { get; set; }
        public int Color { get; set; }
    }
