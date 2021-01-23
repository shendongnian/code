    <%@ Page Language="C#" %>
    <%@ Import Namespace="Newtonsoft.Json" %>
    <script runat="server">
    internal class myObject
    {
        public string id;
        public string title;
        public string start;
        public string end;
        public string url;
    }
    string json = JsonConvert.SerializeObject(new List<myObject>()
                        {
                            new myObject()
                            {
                                id = "111",
                                title = "Event1",
                                start = String.Format("{0}-{1}-10", DateTime.Now.Year, DateTime.Now.Month),
                                url = "http://yahoo.com/"
                            },
                            new myObject()
                            {
                                id = "222",
                                title = "Event2",
                                start = String.Format("{0}-{1}-20", DateTime.Now.Year, DateTime.Now.Month),
                                url = "http://yahoo.com/"
                            }
                        }); 
    </script>
    <%= json %>
