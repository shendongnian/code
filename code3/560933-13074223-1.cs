                    HttpCachePolicyBase cachePolicy = context.HttpContext.Response.Cache;
                    cachePolicy.SetCacheability(bundleResponse.Cacheability);
                    cachePolicy.SetOmitVaryStar(true);
                    cachePolicy.SetExpires(DateTime.Now.AddYears(1));
                    cachePolicy.SetValidUntilExpires(true);
                    cachePolicy.SetLastModified(DateTime.Now);
                    cachePolicy.VaryByHeaders["User-Agent"] = true;
