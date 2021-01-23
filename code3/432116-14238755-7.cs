    public static IHtmlString CheckCorrectCollectionName(this HtmlHelper htmlHelper, string partialName, IHtmlString somethingToBeRendered)
{
                //TODO: check http://aspnet.codeplex.com/workitem/5495 to remove this fix
    
                if (partialName.StartsWith("["))
                {
                    string fullHtmlFieldName = htmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(partialName);
    
                    if (fullHtmlFieldName.EndsWith("." + partialName))
                    {
                        string htmlCode = somethingToBeRendered.ToHtmlString();
    
                        string nameAttribute = "name=\"" + fullHtmlFieldName + "\"";
                        var p = htmlCode.IndexOf(nameAttribute);
    
                        int endIndex = p + nameAttribute.Length - partialName.Length - 2;
                        var correctedHtmlCodeStart = htmlCode.Substring(0, endIndex);
                        var correctedHtmlCodeEnd = htmlCode.Substring(endIndex+1);
    
                        return new HtmlString(correctedHtmlCodeStart + correctedHtmlCodeEnd);
                    }
                }
    
                return somethingToBeRendered;
