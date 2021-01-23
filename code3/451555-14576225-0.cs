    <http://dotnetpools.com/Article/ArticleDetiail/?articleId=48&title=Binding%20Dropdownlist%20In%20MVC3%20Using%20C#t;>
    
    ## razor ##
    
        @Html.DropDownList("Country", new SelectList(Model.CountryList, "Value", "Text", Model.CountryList.SelectedValue), new { @id = "ddlist", @data_role = "none", style = "color: #fff; background-color: #fff; font-family: Arial, Helvetica, sans-serif; font-size: 10px; color: #333333; margin-left:3px; width:100%; height:20px;" })
    
    
    ## model ##
    
         public class somename
          {
           public SelectList CountryList { get; set; }
          }
           public class Country
            {
                public string ID { get; set; }
                public string Name { get; set; }
            }
    
    ## Controller ##
      
           public ActionResult index()
            {
              List<Country> objcountry = new List<Country>();
              objcountry = GetCountryList();
              SelectList objlistofcountrytobind = new SelectList(objcountry, "ID", "Name", 0);
              model.CountryList = objlistofcountrytobind;       
              return View(model);
            }
    
    
          [HttpPost]
          public ActionResult Analyze(AnalyzeModels model)
           {
              List<Country> objcountry = new List<Country>();
              objcountry = GetCountryList();
              SelectList objlistofcountrytobind = new SelectList(objcountry, "ID", "Name", 0);
              model.CountryList = objlistofcountrytobind;
              return View(model);
           }
                  **************************************************
    ## function for GetCountryList##
            public List<Country> GetCountryList()
            {
                DataTable reportDetailsTable = objCommon.GetDetails("tablename");
    
                List<Country> objcountrty = new List<Country>();
                int s = reportDetailsTable.Rows.Count;
                for (int i = 0; i < s; i++)
                {
                    string d1 = reportDetailsTable.Rows[i][1].ToString();
                    string d2 = reportDetailsTable.Rows[i][10].ToString();
                    objcountrty.Add(new Country { ID = d1, LName = d2 });
                }
                return objcountrty;
            }
