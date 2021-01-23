    DateTime dt = DateTime.Now;
            string t =dt.TimeOfDay.ToString();
            int ind=t.LastIndexOf(".");
            if(ind>0)
            t = t.Substring(0,ind);
            Response.Write(t);
