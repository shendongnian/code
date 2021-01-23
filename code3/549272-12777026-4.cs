    @Html.DropDownListFor(model => model.Title, new SelectList(Model.ls, "value", "text"), Model.nvc)
     
     <!--
     @Html.DropDownList("myIdAndName", new SelectList(Model.ls, "value", "text"), Model.nvc)
     -->
        public ActionResult Index()
        {
            cHomeModel HomeModel = new cHomeModel();
            HomeModel.nvc.Add("class", "chzn-select");
            HomeModel.nvc.Add("data-placeholder", "Choose a customer");
            HomeModel.nvc.Add("style", "width:350px;");
            HomeModel.nvc.Add("tabindex", "1");
            HomeModel.nvc.Add("multiple", "multiple");
            HomeModel.nvc.Add("id", "lol");
            cOption option = null;
           
            for (int i = 0; i < 10; ++i)
            {
                option = new cOption();
                
                option.value = i.ToString();
                option.text = "text" + i.ToString();
                HomeModel.ls.Add(option);
            }
            return View(HomeModel);
        }
        public class cOption
        {
            public string value
            {
                get;
                set;
            }
            public string text
            {
                get;
                set;
            }
        }
        public class cHomeModel
        {
            public string Title = "MyDropDownListName";
            public List<cOption> ls = new List<cOption>();
            public System.Collections.Generic.Dictionary<string, object> nvc = new System.Collections.Generic.Dictionary<string, object>();
        }
