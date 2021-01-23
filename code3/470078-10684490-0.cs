      public class StaticViewModel : BaseViewModel
      {
          public enum WhichOne
          {
              AboutPage,
              InfoPage,
              HelpPage,
              // etc
          }
          public WhichOne WhichPage { get; set; }
          public StaticViewModel(string which)
          {
              WhichPage = (WhichOne) Enum.Parse(typeof(WhichOne), which, false);
          }
      }
