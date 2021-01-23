    using System;
    using System.Collections.Generic;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.Xml;
    using System.Data;
    using System.ServiceModel.Syndication; // used for feed implementation
    
    public partial class FeedConsume : System.Web.UI.Page
    {
        /// <summary>
        /// databind function of listview is called from this function.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            // See if feed data is in the cache
            IEnumerable<SyndicationItem> items = Cache["Feeds"] as IEnumerable<SyndicationItem>;
            if (items == null)
            {
                // If not present in cache then get it from sender's website
                try
                {
                    SyndicationFeed sfFeed = SyndicationFeed.Load(XmlReader.Create("FEED URL OF senders website"));
                    
                    // every website has a static url which contains their feed and we can get the feed from that url. 
                    items = sfFeed.Items;
                    }
                catch
                {
                    items = new List<SyndicationItem>();
                }
                // Add the items to the cache
                Cache.Insert("Feeds", items, null, DateTime.Now.AddHours(1.0),TimeSpan.Zero);
            }
            // Creating the datatable to bind it to the listview. This datatable will contain all the feeds from the senders website.
            DataTable dtItems = new DataTable();
            dtItems.Columns.Add("Title", typeof(string));
            dtItems.Columns.Add("Link", typeof(string));
            foreach (SyndicationItem synItem in items)
            {
                dtItems.Rows.Add(synItem.Title.Text, synItem.Links[0].Uri.ToString());
            }
            FeedList.DataSource = dtItems;
            FeedList.DataBind(); 
        }
    
        /// <summary>
        /// Controls in listView are assigned proper value
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void FeedList_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            ListViewDataItem lvDataItem = (ListViewDataItem)e.Item;
            DataRowView drvItem = (DataRowView)lvDataItem.DataItem;
            Label title = (Label)e.Item.FindControl("title");
            title.Text = drvItem["Title"].ToString();
            HyperLink link = (HyperLink)e.Item.FindControl("link");
            link.Text = drvItem["Link"].ToString();
            link.NavigateUrl = drvItem["Link"].ToString();
        }
    }
