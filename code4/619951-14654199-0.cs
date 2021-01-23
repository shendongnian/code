    class Presenter {
        readonly IView view;
        readonly IModel model;
    
        public Presenter() {
            // if view needs ref. to presenter, pass into view ctor
            view = new View(this);
            model = new Model();
        }
    }
