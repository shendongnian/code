    public static HtmlHelper GetHtmlHelper( this Controller controller )
            {
                var viewContext = new ViewContext( controller.ControllerContext, new FakeView(), controller.ViewData, controller.TempData, TextWriter.Null );
                new HtmlHelper( viewContext, new ViewPage() ).RenderPartial("/mypartial");
            }
    
            public class FakeView : IView
            {
                public void Render( ViewContext viewContext, TextWriter writer )
                {
                    throw new InvalidOperationException();
                }
            }
