        public class CodeBehindPage : System.Web.UI.Page, IViewInterface {
            private Presenter myPresenter;
            public CodeBehindPage() {
                myPresenter = new Presenter(this); // Presenter will require IViewInterface
            }
        }
