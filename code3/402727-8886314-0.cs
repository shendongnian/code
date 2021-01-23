    public class DLaddRestApp
    {
        RestaurantsEntities db = new RestaurantsEntities();
        public IEnumerable<int> addResApp(string RestName, string RestStreet, string RestCity, string RestZip, string RestPhone, string ContactFname, string ContactLname, string ContactEmail, string ContactPhone)
        {
            APP_REST appRest = new APP_REST();
            appRest.APP_REST_NAME = RestName;
            appRest.APP_REST_STREET = RestStreet;
            appRest.APP_REST_CITY = RestCity;
            appRest.APP_REST_ZIP = RestZip;
            appRest.APP_REST_PHONE = RestPhone;
            appRest.APP_CONTACT_FNAME = ContactFname;
            appRest.APP_CONTACT_LNAME = ContactLname;
            appRest.APP_CONTACT_EMAIL = ContactEmail;
            appRest.APP_CONTACT_PHONE = ContactPhone;
            appRest.APP_DESC_CUISINE = "";
            db.AddToAPP_REST(appRest);
            db.SaveChanges();
            var appRestId = from APP_REST in db.APP_REST
                    orderby APP_REST.APP_CODE ascending
                    select APP_REST.APP_CODE;
            return appRestId;        
        }
