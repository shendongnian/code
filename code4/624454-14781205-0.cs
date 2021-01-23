    public abstract class CultureAwarePage : Page
    {
       protected override void InitializeCulture() { ... }
    }
    public partial class MyPage1 : CultureAwarePage
    {
      ...
    }
