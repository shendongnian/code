        public class AppStart
            : MvxNavigatingObject
            , IMvxAppStart		
        {
            public void Start(object hint = null)
            {
                var authService = Mvx.Resolve<IMySerice>();
                if (authService.IsLoggedIn)
                {
                    ShowViewModel<HomeViewModel>();
                }
                else
                {
                    ShowViewModel<LoginViewModel>();
                }
            }
        }
    (you can see another example in https://github.com/slodge/MvvmCross/blob/v3/Sample%20-%20CirriousConference/Cirrious.Conference.Core/ApplicationObjects/AppStart.cs)
    This can be registered in App.cs startup using:
        RegisterAppStart(new AppStart());
