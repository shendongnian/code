    foreach (var entity in metadata.Meta.Where(e => e.ReportableObject == true))
    {
          LinkButton lb = new LinkButton();
          string iconpath = ResolveClientUrl("~/images/search/" + entity.ClassName + ".png");
          lb.CssClass = "entityIcon";
          lb.Text = string.Format(@"image <img src=""{0}"" class=""{1}"" />",iconpath,"imgSize");
          lb.Text = entity.ClassName;
          entityHolder.Controls.Add(lb);
    }
