    class Presenter : IPresenter<IView>
    {
        public void setView(IView view) {}
    }
    IPresenter<IViewA> presenter = new Presenter();
