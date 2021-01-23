    public override void RenderControl(HtmlTextWriter writer)
    {
          //...
          //Fill in the variable HtmlText content
          //Split it to 2 variables - before and after the control place, and:
                
          writer.Write(startString);
          base.RenderControl(writer);
          writer.Write(endString);
    }
