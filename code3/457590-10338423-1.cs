    var query = 
    (
       from t in Concept_Texts
       join c in Concept_Text_Categories on t.CategoryId equals c.CategoryId
       join cp in Concept_Text_CategoryToPlugin on c.CategoryId equals cp.CategoryId
       join p in Concept_Text_Plugins on cp.CategoryId equals p.CategoryId
       where p.type = 12 && t.IsPublished == "True" AND t.Visible == "True"
       group cp by new {t.TextId, t.Title, t.CategoryId, c.Name, t.DateSent} into gr
       orderby gr.Key.DateSent descending
       select new {
                  gr.Key.TextId, 
                  gr.Key.Title, 
                  gr.Key.CategoryId, 
                  gr.Key.Name, 
                  gr.Key.DateSent,
                  MinCpCategoryId = gr.Min(gcp=>gcp.CategoryId },
                  MaxCpCategoryId = gr.Max(gcp=>gcp.CategoryId }
    ).Take(12);
