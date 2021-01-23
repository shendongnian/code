        public class SomeViewModel : ViewModelBase<SomeModel>
        {
            //implemented in the base class:
            //public Model SomeModel { get; }
	
            internal ICommand SomeMethodThatIsReallyOnMyModel
            {
                get
                {
                     return _someCommandYouHaveImplementedToDoJustThis;
                }
                //_someCommandYouHaveImplementedToDoJustThis.Execute:
                //Model.SomeMethod()
            }
	
        //...
    }
