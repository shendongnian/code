	using umbraco.BusinessLogic;
	using System.Web.Profile;
	using System;
	namespace zo.Umb.LastLogin
	{
		// this approac works, and it may be necessary to extend the membership provider in the future, so that's why I'm
		// leaving it here. But for now I'm using the ApplicationStartupHandler event subscription method
		// in MemberEvent.cs
		/// <summary>
		/// Inherit the default membership provider and substitute my own method that's fired when a member tries
		/// to log in. Note that you must also replace the UmbracoMembershipProvider reference in the web.config 
		/// with a reference to this one. eg:
		/// <add name="UmbracoMembershipProvider" type="zo.Umb.LastLogin.MyMembershipProvider" enablePasswordRetrieval="false" enablePasswordReset="false" requiresQuestionAndAnswer="false" defaultMemberTypeAlias="Another Type" passwordFormat="Hashed" />
		/// 
		/// also note that, to have custom profile properties appear, they must also be added in the web.config
		/// like so:
		/// <profile defaultProvider="UmbracoMemberProfileProvider" enabled="true">
		///  <providers>
		///    <clear />
		///    <add name="UmbracoMemberProfileProvider" type="umbraco.providers.members.UmbracoProfileProvider, umbraco.providers" />
		///  </providers>
		///  <properties>
		///    <clear />
		///    <add name="lastLogin" allowAnonymous ="false" provider="UmbracoMemberProfileProvider" type="System.DateTime" />
		///  </properties>
		///</profile>
		/// </summary>
		public class MyMembershipProvider : umbraco.providers.members.UmbracoMembershipProvider
		{
			public override bool ValidateUser(string username, string password)
			{
				var success = base.ValidateUser(username, password);
				if (success)
				{
					var user = GetUser(username, true);
					var profile = ProfileBase.Create(user.UserName);
					profile["lastLogin"] = DateTime.Now;
					profile.Save();
				}
				return success;
			}
		}
	}
