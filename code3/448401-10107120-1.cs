    public class TestBase
        {
            internal Mock<HttpContextBase> Context;
            internal Mock<HttpRequestBase> Request;
            internal Mock<HttpResponseBase> Response;
            internal Mock<HttpSessionStateBase> Session;
            internal Mock<HttpServerUtilityBase> Server;
            internal GenericPrincipal User;
                public void SetContext(Controller controller)
                {
                  Context = new Mock<HttpContextBase>();
                  Request = new Mock<HttpRequestBase>();
                  Response = new Mock<HttpResponseBase>();
                  Session = new Mock<HttpSessionStateBase>();
                  Server = new Mock<HttpServerUtilityBase>();
           User = new GenericPrincipal(new GenericIdentity("test"), new string[0]);
                  Context.Setup(ctx => ctx.Request).Returns(Request.Object);
                  Context.Setup(ctx => ctx.Response).Returns(Response.Object);
                  Context.Setup(ctx => ctx.Session).Returns(Session.Object);
                  Context.Setup(ctx => ctx.Server).Returns(Server.Object);
                  Context.Setup(ctx => ctx.User).Returns(User);
                  Request.Setup(r => r.Cookies).Returns(new HttpCookieCollection());
                  Request.Setup(r => r.Form).Returns(new NameValueCollection());
          Request.Setup(q => q.QueryString).Returns(new NameValueCollection());
                  Response.Setup(r => r.Cookies).Returns(new HttpCookieCollection());
                  var rctx = new RequestContext(Context.Object, new RouteData());
    controller.ControllerContext = new ControllerContext(rctx, controller);
                }
    }
