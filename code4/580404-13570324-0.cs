                int contentId;
                if (Int32.TryParse(content, out contentId))
                {
                    model = service.GetBlogById(contentId);
                    if(model != null)
                    {
                        return RedirectResult(/*url using the title*/);
                    }
                }
                else
                {
                    model = service.GetBlogByTitle(content);
                }
    
                //Change URL to be: www.testurl.com/sports/blog/ + model.SEOFriendlyTitle
                return View(model);
