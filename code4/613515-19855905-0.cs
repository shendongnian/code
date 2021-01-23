      public class Criteria {
        public decimal? ANullableNumber { get; set; }
        public IList<ObjectInList> ObjectsList { get; set; }
      }
      public class Criteria1 {
        private IList<ObjectInList> _ls;
        private decimal? _num;
        public decimal? ANullableNumber {
          get {
            if (_num == null) return 0;
            return _num;
          }
          set {
            _num = value;
          }
        }
        public IList<ObjectInList> ObjectsList {
          get {
            if (_ls == null) _ls = new List<ObjectInList>();
            return _ls;
          }
          set {
            _ls = value;
          }
        }
      }
      public class HomeController : Controller {
        public ActionResult Index() {
          var dd = new Criteria();
          return Json(dd);    //output: {"ANullableNumber":null,"ObjectsList":null}
        }
        public ActionResult Index1() {
          var dd = new Criteria1();
          return Json(dd);    //output: {"ANullableNumber":0,"ObjectsList":[]}
        }
      }
