    public interface IPage {
        public HttpResponse Response { get; set; }
    }
    public class Page1 : IPage {
    }
    public class Page2 : IPage {
    }
    public class CheckuserAuthentication {
        private IPage _page;
        public CheckuserAuthentication(IPage page) {
            _page = page;
        }
        public void AuthenticateUser(out Person person, out Animal animal) {
            _page.Response.Write("Doesn't matter what page it writes to.. it will write to whatever you pass in..");
        }
    }
