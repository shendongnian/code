    [PermissionSet(SecurityAction.Demand, Name = "FullTrust")] // Note full trust.
    [System.Runtime.InteropServices.ComVisibleAttribute(true)]
    public partial class BasicJSScriptableForm : Form
    {
      private void BasicJSScriptableForm _Load(object sender, EventArgs e){
         this.WebBrowser1.Navigate("yourpage");
      }
      public string TestMethod(string input){
         return string.Format("echo: {0}", input);
      }
    }
