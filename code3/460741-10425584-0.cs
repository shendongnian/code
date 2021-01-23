    <%@ Application Language="C#" %>
    <script runat="server">
        
        public override void Init()
        {
            this.BeginRequest += new EventHandler(global_asax_BeginRequest);        
            base.Init();
        }
    
        void global_asax_BeginRequest(object sender, EventArgs e)
        {
            
        }    
           
    </script>
