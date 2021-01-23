    namespace Project.MyWebControls
    {
        public class MyDropDownList : System.Web.UI.WebControls.DropDownList
        { 
            protected override bool LoadPostData(string postDataKey, NameValueCollection postCollection)
            {
                if (base.LoadPostData(postDataKey, postCollection))
                    return true;
            
                // this means that the value selected was not present in the .Items collection
                string[] values = postCollection.GetValues(postDataKey);
                if (values == null || values.Length == 0)
                    return false;
            
                // add the value to the Items collection so that it can be processed later on.
                this.Items.Add(new ListItem("Custom value created by JavaScript", values[0]));
                this.SetPostDataSelection(this.Items.Count - 1);
            }
        }
    }
