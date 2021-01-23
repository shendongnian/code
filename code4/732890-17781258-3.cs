        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Write(Request.RawUrl.ToString()); // redirect on itself
            Response.Write("<br /> Counter =" + Counter.GetCounter() ); // display counter value
        }
