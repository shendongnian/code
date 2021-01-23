    < %@ Control Language="c#" AutoEventWireup="true" EnableViewState="false" %>
    < %@ Import namespace="System.Xml" %>
    < script runat="server" language="C#">
        public string rssUrl = "http://blogs.x2line.com/al/rss.aspx";
        private System.Xml.XmlDocument doc;
       
        public override void DataBind()
        {
            doc = new System.Xml.XmlDocument();
            doc.Load(rssUrl);
             
            base.DataBind();
        }
             
        public void Page_Load(System.Object s, System.EventArgs e)
        {
            this.DataBind();
        }
    < /script>
    
    < asp:Repeater 
        runat="server" 
        id="rptrRss" 
        DataSource='< %# doc.SelectNodes("/rss/channel/item[position()<=5]") %>'>
        < HeaderTemplate>
            < div>
                < a href='< %# doc.SelectSingleNode("/rss/channel/image/link").InnerText %>'>
                < img 
                    src='< %# doc.SelectSingleNode("/rss/channel/image/url").InnerText %>' 
                    alt='< %# doc.SelectSingleNode("/rss/channel/image/title").InnerText %>' />
                < /a>
        < /HeaderTemplate>
        < ItemTemplate>
            < a 
                href='< %# (Container.DataItem as XmlNode)["link"].InnerText %>'>
                < %# (Container.DataItem as XmlNode)["title"].InnerText %>
                (< %# (Container.DataItem as XmlNode).SelectSingleNode("author |
    title[not(../author)]").InnerText %>)
            < /a>
        < /ItemTemplate>
        < FooterTemplate> 
            < /div>
        < /FooterTemplate>
    < /asp:Repeater>
