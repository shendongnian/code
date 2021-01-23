    protected void Page_Load(object sender, EventArgs e)
    {
        ContentPlaceHolder c = Page.Master.FindControl("ScriptsPlace") as ContentPlaceHolder;
        if (c != null)
        {
            LiteralControl l = new LiteralControl();
            l.Text="<script type=\"text/javascript\">$(document).ready(function () {js stuff;});</script>";
            c.Controls.Add(l);
        }
    }
