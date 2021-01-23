          NameValueCollection v = Request.QueryString;
        if (v.HasKeys())
        {
            string k = v.GetKey(0);
            string n = v.Get(0);
            if (k == "value")
            {
                lbltext.Text = n.ToString();
            }
            if (k == "value1")
            {
                lbltext.Text = "error occured";
            }
        }
