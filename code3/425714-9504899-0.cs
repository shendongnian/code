    public partial class PlayerView : IHaveAPlayCommand
    {
    public PlayerView()
    {
          this.DataContext = new ViewModel(this);
    }
    }
    public class ViewModel
    {
          IHaveAPlayCommand view;
          public ViewModel(IHaveAPlayCommand view)
          {
               this.view = view
          }
    }
