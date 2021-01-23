	using System;
	//using umbraco.BusinessLogic;
	using umbraco.businesslogic;
	using umbraco.cms.businesslogic.member;
	namespace zo.Umb.LastLogin
	{
		public class MemberEvent : ApplicationStartupHandler
		{
			public MemberEvent()
			{
				Member.BeforeSave += new Member.SaveEventHandler(Member_BeforeSave);
			}
			void Member_BeforeSave(Member sender, umbraco.cms.businesslogic.SaveEventArgs e)
			{
				//Log.Add(LogTypes.Debug, sender.Id, "Member_AfterAddToCache");
				sender.getProperty("lastLogin").Value = DateTime.Now;
			}
	   }
	}
