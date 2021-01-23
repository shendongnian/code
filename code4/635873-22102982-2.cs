        public class NewModel
        {
          public int ID { get; set; }
          public int UserID { get; set; }
          public string Description { get; set; }
          public class WrapperForHtmlHelper : System.Web.Mvc.IViewDataContainer
          {
            public System.Web.Mvc.ViewDataDictionary ViewData { get; set; }
            public WrapperForHtmlHelper(NewModel value)
            {
                this.ViewData = new System.Web.Mvc.ViewDataDictionary<NewModel>(value);
            }
          }
        }
