			 public partial class MyNewView : Microsoft.Practices.CompositeWeb.Web.UI.Page, IMyNewViewView
			 {
				private MyNewViewPresenter _presenter;
			
				protected void Page_Load(object sender, EventArgs e)
				{
					if (!this.IsPostBack)
					{
						this._presenter.OnViewInitialized();
					}
					this._presenter.OnViewLoaded();
				}
			
				[CreateNew]
				public MyNewViewPresenter Presenter
				{
					get
					{
						return this._presenter;
					}
					set
					{
						if (value == null)
							throw new ArgumentNullException("value");
			
						this._presenter = value;
						this._presenter.View = this;
					}
				}
			
				// TODO: Forward events to the presenter and show state to the user.
				// For examples of this, see the View-Presenter (with Application Controller) QuickStart:
				//	
			
			}
			
			public interface IMyNewViewView
			{
			}
			
			public class MyNewViewPresenter : Presenter<IMyNewViewView>
			{
			
				// NOTE: Uncomment the following code if you want ObjectBuilder to inject the module controller
				//       The code will not work in the Shell module, as a module controller is not created by default
				//
				// private IShellController _controller;
				// public MyNewViewPresenter([CreateNew] IShellController controller)
				// {
				// 		_controller = controller;
				// }
			
				public override void OnViewLoaded()
				{
					// TODO: Implement code that will be executed every time the view loads
				}
			
				public override void OnViewInitialized()
				{
					// TODO: Implement code that will be executed the first time the view loads
				}
			
				// TODO: Handle other view events and set state in the view
			}
