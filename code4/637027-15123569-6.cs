    <%@ Page Language="C#" %>
    <%@ Import Namespace="Newtonsoft.Json" %>
    <script runat="server">
        string json = JsonConvert.SerializeObject(new[]
            {
                new
                {
                    id = "111",
                    title = "Event1",
                    start = String.Format("{0}-{1}-10", DateTime.Now.Year, DateTime.Now.Month),
                    url = "http://yahoo.com/"
                },
                new
                {
                    id = "222",
                    title = "Event2",
                    start = String.Format("{0}-{1}-20", DateTime.Now.Year, DateTime.Now.Month),
                    url = "http://yahoo.com/"
                }
            }); 
    </script>
    <%= json %>
