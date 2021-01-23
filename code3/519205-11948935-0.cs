    namespace Whatever {
	public class MyModel
	{
		public IEnumerable<ProfileUser> ProfileUsers
		{
			get
			{
				return profile == null ? null : profile.ProfileUser;
			}
			set
			{
				profile.ProfileUser = value; // btw, no nullchecks here?
			}
		}
	}
	public class ProfileUser [: DependencyObject] -- I do not remember if the inheritance is REQUIRED. Try without it first.
	{
		public string User_ID {get;set;}
		public string Login {get;set;}
		public string Address {get;set;}
		//- Operator User {get{}} -- does NOT exist here
	}
	public class Operator
	{
		public ProfileUser RelatedUser {get;set;}
		public string OperatorCodename {get;set;}
		public int PermissionLevel {get;set;}
	}
	public static class ProfileUserExtras
	{
		public static readonly DependencyProperty UserProperty = DependencyProperty.RegisterAttached(
			"User",				// the name of the property
			typeof(Operator), 	// property type
			typeof(ProfileUser), // the TARGET type that will have the property attached to it
			
			new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsRender) // whatever meta you like
		);
		// name of this method MUST match the naming: Get{PropertyName}
		public static Operator GetIsBubbleSource(UIElement element)
		{
			var dtx = element.DataContext as ProfileUser;
			if(dtx == null) return null;
			
			return OperatorManager.GetByGuId(dtx.User_ID); // this is it!
		}
		// your property is read-only, so you do not need the following, but I show it for reference:
		// name of this method MUST match the naming: Set{PropertyName}
		//public static void SetUser(UIElement element, Operator value)
		//{
		//	var dtx = element.DataContext as ProfileUser;
		//	if(dtx == null) return;
		//
		//  ... do something
		//}
	}
    }
