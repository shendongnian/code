    public class RestrictDate : ActionFilterAttribute
    {
        private int _monthFrom ;
        private int _monthTo;
        private int _dayFrom = 1;
        private int _dayTo = 0;
        public RestrictDate(int monthFrom, int monthTo)
        {            
            _monthFrom = monthFrom;
            _monthTo = monthTo;
        }
        public RestrictDate(int monthFrom, int dayFrom, int monthTo, int dayTo)
            : this(monthFrom, monthTo)
        {
            _dayFrom = dayFrom;
            _dayTo = dayTo;
        }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
           
            DateTime minDate = new DateTime(DateTime.Today.Year, _monthFrom, _dayFrom);
            
            int interval = _monthFrom <= _monthTo ? _monthTo - _monthFrom : 12 - _monthFrom  + _monthTo;
            DateTime maxDate;
            if (_dayTo == 0)
            {
                maxDate = minDate.AddMonths(interval + 1).AddDays(-1);
            }
            else
            {
                maxDate = new DateTime(DateTime.Today.Year, _monthFrom, 1).AddMonths(interval).AddDays(_dayTo - 1);
            }
            if (DateTime.Today < minDate || DateTime.Today > maxDate)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                {
                    controller = "Home",
                    action = "Error"
                }));
            }
            
            base.OnActionExecuting(filterContext);
        }
    }
