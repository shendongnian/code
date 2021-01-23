    namespace WhitePoint.Solutions.Web 
    { 
        public abstract class WhitePointHttpApplicationBase : HttpApplication { 
        
            protected WhitePointHttpApplicationBase()
            {
                this.BeginRequest += WhitePointHttpApplicationBase_BeginRequest; 
            }
            #region "Member" 
            #endregion 
        
            private void WhitePointHttpApplicationBase_BeginRequest(object sender, EventArgs e) { } 
        } 
    } 
