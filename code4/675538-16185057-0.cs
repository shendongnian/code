    private void RemoveLinks(Control grdView)
        {
            LinkButton lb = new LinkButton();
            Literal l = new Literal();
    
            for (int i = 0; i < grdView.Controls.Count; i++)
            {
                if (grdView.Controls[i].GetType() == typeof(LinkButton))  // or hyperlink
                {
                    l.Text = (grdView.Controls[i] as LinkButton).Text;
                    grdView.Controls.Remove(grdView.Controls[i]);
                    grdView.Controls.AddAt(i, l);
                }
                if (grdView.Controls[i].HasControls())
                {
                    RemoveLinks(grdView.Controls[i]);
                }
            }        
        }
