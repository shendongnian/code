    using System.Text;
    using System.IO;
    using System.Web.UI;
    public string RenderControl(Control ctrl)
    {
        StringBuilder sb = new StringBuilder();
        StringWriter tw = new StringWriter(sb);
        HtmlTextWriter hw = new HtmlTextWriter(tw);
        ctrl.RenderControl(hw);
        return sb.ToString();
    }
