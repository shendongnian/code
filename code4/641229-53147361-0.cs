    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    namespace SomeNameSpace
    {
    	public static class CSession
    	{
    		private static readonly string zE = "";
    		private static readonly string CrLF = Environment.NewLine;
    
    
    		/// <summary>
    		/// 
    		/// </summary>
    		public static bool HasSession { get { return HttpContext.Current != null && HttpContext.Current.Session != null; } }
    
    
    		/// <summary>
    		/// Get a session variable
    		/// </summary>
    		/// <param name="pSessionKey"></param>
    		/// <returns></returns>
    		public static object Get(string pSessionKey)
    		{
    			object t = null;
    			try
    			{
    				if (HasSession && HttpContext.Current.Session[pSessionKey] != null) { t = (object)HttpContext.Current.Session[pSessionKey]; }
    
    			}
    			catch (Exception ex) { t = null; string m = ex.Message; }
    			return t;
    		}//object Get(string pSessionKey)
    
    
    
    		/// <summary>
    		/// Set a session variable
    		/// </summary>
    		/// <param name="pSessionKey"></param>
    		/// <param name="pObject"></param>
    		public static void Set(string pSessKey, object pObject)
    		{
    			if(!HasSession) { return; }
    			HttpContext.Current.Session.Remove(pSessKey);
    			HttpContext.Current.Session.Add(pSessKey, pObject);
    		}//void Set(string pSessionKey, object pObject)
    
    
    		public static string GetString(string pSessKey)
    		{
    			string sTemp = zE;
    			object t = Get(pSessKey);
    			if (t != null) { sTemp = (string)t; } else { sTemp = zE; }
    			return sTemp;
    		}//string GetString(string pSessionKey)
    
    
    		public static int GetInt(string pSessKey)
    		{
    			int s = 0;
    			object t = Get(pSessKey);
    			if (t != null) { s = (int)t; }
    			return s;
    		}//int GetInt(string pSessionKey)
    
    
    		public static Int32 GetInt32(string pSessKey)
    		{
    			Int32 s = 0;
    			object t = Get(pSessKey);
    			if (t != null) { s = (Int32)t; }
    			return s;
    		}//Int32 GetInt32(string pSessionKey)
    
    
    		public static bool GetBool(string pSessKey)
    		{
    			bool s = false;
    			object t = Get(pSessKey);
    			if (t != null) { s = (bool)t; }
    			return s;
    		}//bool GetBool(string pSessionKey)
    
    	}//public static class CSession
    
    }
