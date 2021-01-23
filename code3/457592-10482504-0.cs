    (from c in Concept_Text_Categories
                                join cp in Concept_Text_CategoryToPlugin
                                on c.CategoryId equals CategoryID
                                join p in Concept_Text_Plugins
                                on PluginID equals p.PluginID
                                where p.Type == 12
                                && c.Enabled
                                && p.Enabled
                                orderby c.Name ascending
                                select new ()
                                {
                                    CategoryId = c.CategoryId,
                                    Name = c.Name,
                                    Materias = (from t in Concept_Text
                                            where t.CategoryId == c.CategoryId
                                            && t.IsPublished
                                            && t.Visible
                                            orderby t.DateSent
                                            select new ()
                                            {
                                                TextId = t.TextId,
                                                Title = t.Title
                                            }).Take(12)
                                })
