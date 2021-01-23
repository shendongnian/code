        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            // this will apply the action in the lambda expression to all controls or sub-controls of the row matching type LinkButton  (you may have a different control type and you may want to alter your lambda expression to check that the control matched is really the control you want to manipulate
            SearchControls<LinkButton>(e.Row, button => button.OnClientClick = "alert('here');");
        }
        // recursive Control search function
        private void SearchControls<T>(Control start, Action<T> itemMatch)
        {
            foreach (var c in start.Controls.OfType<T>())
                itemMatch(c);
            foreach (var c in start.Controls.OfType<Control>())
                SearchControls<T>(c, itemMatch);
        }
