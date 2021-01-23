    interface IView {}
    
    interface IViewA : IView {}
    class ViewA : IViewA {}
    
    interface IViewB : IView {}
    class ViewB : IViewB {}
    
    interface IPresenter<in T> where T : IView
    {
        void setView(T view);
    }
    
    class PresenterA : IPresenter<IViewA>
    {
        public void setView(IViewA view) {}
    }
    
    class PresenterB : IPresenter<IViewB>
    {
        public void setView(IViewA view) {}
    }
