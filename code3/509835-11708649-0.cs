    ...
        void Properties_Completed(object sender, LiveOperationCompletedEventArgs e)//completed
        {
            if (e.Error == null)
            {
                IDictionary<string,object> result = e.Result;
                object shr = result["shared_with"];
                IDictionary<string, object> permission = shr as IDictionary<string, object>;
                string access = permission["access"].ToString();
            }
        {
