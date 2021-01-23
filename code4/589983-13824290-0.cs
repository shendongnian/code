		public string GetValidUrl(string id)
		{
			string ret = string.Empty;
			if (/*it is item id*/)
			{
				ret = string.Format("~/Admin/UpdateContact.aspx?ContactID={0}", id);
			}
			else if (/*it is contact id*/)
			{
				ret = string.Format("~/LoggedIn/ItemDetails.aspx?ItemID={0}", id);
			}
			return ret;
		}
