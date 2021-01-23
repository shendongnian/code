    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    
    namespace ASPTest
    {
        public partial class RepeaterPage : Page
        {
            private List<Item> cache;
            public List<Item> ItemValues
            {
                get
                {
                    if (cache != null)
                    {
                        return cache;
                    }
                    // load values from database for instance
                    cache = Session["values"] as List<Item>;
                    if (cache != null)
                    {
                        return cache;
                    }
                    Session["values"] = cache = new List<Item>();
                    return cache;
                }
            }
    
            protected override void OnInit(EventArgs e)
            {
                base.OnInit(e);
                listofvalues.DataBinding += bindValues;
            }
    
            protected override void OnLoad(EventArgs e)
            {
                base.OnLoad(e);
                if (!Page.IsPostBack)
                {
                    DataBind();
                }
            }
    
            protected void OnAddItem(object sender, EventArgs e)
            {
                ItemValues.Add(new Item("some value"));
                DataBind();
            }
    
            protected void OnReadValues(object sender, EventArgs e)
            {
                foreach (RepeaterItem repeateritem in listofvalues.Items)
                {
                    TextBox box = (TextBox)repeateritem.FindControl("ValueBox");
                    HiddenField idfield = (HiddenField)repeateritem.FindControl("ID");
                    Item item = findItem(idfield.Value);
                    item.Value = box.Text;
                }
                StringBuilder builder = new StringBuilder();
                foreach (Item item in ItemValues)
                {
                    builder.Append(item.Value).Append(";");
                }
                values.Text = builder.ToString();
            }
    
            private Item findItem(string idvalue)
            {
                Guid guid = new Guid(idvalue);
                foreach (Item item in ItemValues)
                {
                    if (item.ID == guid)
                    {
                        return item;
                    }
                }
                return null;
            }
    
            private void bindValues(object sender, EventArgs e)
            {
                listofvalues.DataSource = ItemValues;
            }
        }
    
        public class Item
        {
            private readonly Guid id;
            private string value;
    
            public Item(string value)
            {
                this.value = value;
                id = Guid.NewGuid();
            }
    
            public Guid ID
            {
                get { return id; }
            }
    
            public string Value
            {
                get { return value; }
                set { this.value = value; }
            }
        }
    }
