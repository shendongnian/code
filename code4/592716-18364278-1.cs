    namespace BLL
    {
        public class tblSubCategory
        {
            public tblSubCategory()
            {
                //
                // TODO: Add constructor logic here
                //
            }
            private int iSubCatId;
            private string sSubCatName;
            private string sImagePath;
            private int iCategoryId;
            private string sDescription;
            private decimal decPrice;
            private int sCategoryName;
            
            public int SubCatId
            {
                get
                { return iSubCatId; }
                set
                { iSubCatId = value; }
            }
            public string SubCatName
            {
                get
                {
                    return sSubCatName;
                }
                set
                { sSubCatName = value; }
            }
            public string ImagePath
            {
                get
                {
                    return sImagePath;
                }
                set
                { sImagePath = value; }
    
            }
            public int CategoryId
            {
                get
                {
                    return iCategoryId;
                }
                set
                { iCategoryId = value; }
            }
            public string Description
            {
                get
                { return sDescription; }
                set
                { sDescription = value; }
            }
            public decimal Price
            {
                get
                { return decPrice; }
                set
                { decPrice = value; }
            }
            public int CategoryName
            {
                get
                {
                    return sCategoryName;
                }
                set
                { sCategoryName = value; }
            }
           
            public int InserttblSubCategory()
            {
                DBAccess db = new DBAccess();
                db.AddParameter("@sSubCatName", sSubCatName);
                db.AddParameter("@sImagePath", sImagePath);
                db.AddParameter("@iCategoryId", iCategoryId);
                db.AddParameter("@sDescription", sDescription);
                db.AddParameter("@decPrice", decPrice);
                return db.ExecuteNonQuery("[tblSubCategory_Insert]", true);
            }
            public DataSet SelectAlltblSubCategory()
            {
                DBAccess db = new DBAccess();
                //db.AddParameter("@iSubCatId", iSubCatId);
                //return db.ExecuteDataSet("tblSubCategory_SelectAllForDDL");
                return db.ExecuteDataSet("tblSubCategory_SelectAll");
            }
            public int UpdatetblSubCategory()
            {
                DBAccess db = new DBAccess();
    
                db.AddParameter("@iSubCatId", iSubCatId);
                db.AddParameter("@sSubCatName", sSubCatName);
                //db.AddParameter("@sImagePath", sImagePath);
                //db.AddParameter("@iCategoryId", iCategoryId);
                db.AddParameter("@sDescription", sDescription);
                db.AddParameter("@decPrice", decPrice);
                return db.ExecuteNonQuery("[tblSubCategory_Update]", true);
            }
            public int DeletetblSubCategory()
            {
                DBAccess db = new DBAccess();
                db.AddParameter("@iSubCatId", iSubCatId);
    
                return db.ExecuteNonQuery("[tblSubCategory_Delete]", true);
            }
            public DataSet SubCategoryAscByCategory()
            {
                DBAccess db = new DBAccess();
                db.AddParameter("@iCategoryId", CategoryId);
    
                return db.ExecuteDataSet("[tblSubCategory_SelectAsc]");
    
            }
            public DataSet SubCategoryDescByCategory()
            {
                DBAccess db = new DBAccess();
                db.AddParameter("@iCategoryId", CategoryId);
    
                return db.ExecuteDataSet("[tblSubCategory_SelectDescPrice]");
    
            }
            public DataSet InnerjointblSubCategory1()
            {
                DBAccess db = new DBAccess();
                db.AddParameter("@iCategoryId", CategoryId);
    
                return db.ExecuteDataSet("[tblSubCategory_InnerJoin1]");
    
            }
            public DataSet SelectDesctblSubCategory()
            {
                DBAccess db = new DBAccess();
                db.AddParameter("@iCategoryId", iCategoryId);
                //db.AddParameter("@sSubCatName", sSubCatName);
                return db.ExecuteDataSet("tblSubCategory_SelectDesc");
            }
            public DataSet SelectSubCatName()
            {
                DBAccess db = new DBAccess();
                db.AddParameter("@iCategoryId", iCategoryId);
    
                return db.ExecuteDataSet("tblSubCategory_SelectSubCatName");
            }
            public DataSet SelectProductsBySubCategory()
            {
                DBAccess db = new DBAccess();
                db.AddParameter("@iSubCatId", iSubCatId);
    
                return db.ExecuteDataSet("tblProduct_ProductBySubCat");
            }
         
            public DataSet selectallsub()
            {
    
                DBAccess db = new DBAccess();
                //db.AddParameter("@iSubCatId", iSubCatId);
                //return db.ExecuteDataSet("tblSubCategory_SelectAllForDDL");
                return db.ExecuteDataSet("tblSubCategory_InnerJoin2");
            }
            public DataSet selectallsubasc()
            {
    
                DBAccess db = new DBAccess();
                //db.AddParameter("@iSubCatId", iSubCatId);
                //return db.ExecuteDataSet("tblSubCategory_SelectAllForDDL");
                return db.ExecuteDataSet("tblSubCategory_InnerJoinDesc");
            }
            public DataSet SelectSubCategoryBySubCatId()
            {
                DBAccess db = new DBAccess();
                db.AddParameter("@iSubCatId", iSubCatId);
    
                return db.ExecuteDataSet("tblSubCategory_ddlProduct");
            }
           
            public DataSet SelectSubCategoryByCategory()
            {
                DBAccess db = new DBAccess();
                db.AddParameter("@iCategoryId", iCategoryId);
    
                return db.ExecuteDataSet("tblSubCategory_SelectSubCategoryByCategory");
            }
            public DataSet GetSubCategory()
            {
                DBAccess db = new DBAccess();
                db.AddParameter("@sSubCatName", sSubCatName);
    
                return db.ExecuteDataSet("tblSubCategory_SelectSname");
            }
            public DataSet SubCategoryByCatAsc()
            {
                DBAccess db = new DBAccess();
                db.AddParameter("@iCategoryId", iCategoryId);
    
                return db.ExecuteDataSet("tblSubCategory_asc");
            }
            public DataSet SubCategoryByCatDesc()
            {
                DBAccess db = new DBAccess();
                db.AddParameter("@iCategoryId", iCategoryId);
    
                return db.ExecuteDataSet("tblSubCategory_desc");
            }
            public DataSet CategoryByCatId()
            {
                DBAccess db = new DBAccess();
                db.AddParameter("@iCategoryId", iCategoryId);
    
                return db.ExecuteDataSet("tblCategory_SelectAllCat");
            }
            public DataSet InnerjointblSubCategoryTop3()
            {
                DBAccess db = new DBAccess();
                //db.AddParameter("@sCategoryName", CategoryName);
                db.AddParameter("@iCategoryId", CategoryId);
                return db.ExecuteDataSet("[tblSubCategory_InnerJoinTop3]");
    
            }
        }
           
    }
