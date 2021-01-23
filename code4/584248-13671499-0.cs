    public ActionResult ViewArticle(int? articleId, string friendlyUrl)
            {
                if (articleId == null)
                {
                    return RedirectToActionPermanent("Index", "Home");
                }
    
                if (Session[string.Format("article-{0}", articleId)] != null)
                {
                    PageMetadata desiredPage = (PageMetadata)Session[string.Format("article-{0}", articleId)];
                    Session[string.Format("article-{0}", articleId)] = null;
                    return View(desiredPage);
                }
    
                var page = context.PageMetadatas.FirstOrDefault(p => p.Id == articleId);
    
                if (page == null)
                {
                    return RedirectToActionPermanent("Index", "Home");
                }
    
                if (friendlyUrl != null)
                {
                    // Redirect to proper name
                    if (friendlyUrl != page.RepresentationString)
                    {
                        Session[string.Format("article-{0}", page.Id)] = page;
                        return RedirectToRoute("Articles", new { controller = "PageManagement", action = "ViewArticle", articleId = articleId, friendlyUrl = page.RepresentationString });
                    }
                    return View(page);
                }
                else
                {
                    Session[string.Format("article-{0}", page.Id)] = page;
                    return RedirectToRoute("Articles", new { controller = "PageManagement", action = "ViewArticle", articleId = articleId, friendlyUrl = page.RepresentationString });
                }
            }
