    protected override void CreateChildControls()
            {
                LinkButton linkButton = Page.LoadControl(_ascxPath) as LinkButton;
                if (linkButton != null)
                {
                    linkButton.Title = LinkText;
                    linkButton.TitleUrl = Link.ToString();
                    /*************************************************************/
                    /* you can replace "alert('test');" with any javascript
                    i.e a function call */
                    linkButton..Attributes.Add("onclick", "alert('test'); ");
                    /*************************************************************/
                    Controls.Add(linkButton);
                }           
            }
