			// Put user code to initialize the page here
			if (Session["SessionId"] == null)
			{
				Response.Redirect("Login.aspx"); 
			}
			Response.Buffer=true;
			Response.ExpiresAbsolute=DateTime.Now.AddDays(-1d);
			Response.Expires = -1500;
			Response.CacheControl ="no-cache";
		}
