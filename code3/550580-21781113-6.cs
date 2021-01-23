    public class ContoscoHttpContext {
      private HttpContextBase _context;
      public ContoscoHttpContext(HttpContextBase context) {
        _context = context;
      }
      public int? GetUserID() {
        // TODO: provide your own implementation how to get user id
        // based on HttpContextBase stored in _context
        // in my case it was something like 
        // return ((ContoscoPrincipal)_context.User).UserID;
      }
    }
