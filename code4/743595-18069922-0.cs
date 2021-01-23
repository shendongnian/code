    var ncms = repository.VIEWNCM; // this should be IQueryable or IEnumerable - no query yet
    
    if(Request.IsAjaxRequest())
    {
        if(!string.IsNullOrEmpty(searchString))
        {
            switch(typeSearch)
            {
                    case "cod":
                        // No query here either!
                        ncms = ncms.Where(e => e.CODIGO_LEITURA.ToLower().Contains(searchString.ToLower()) || e.CODIGO.ToLower().Contains(searchString.ToLower()));
                        break;
                    default:
                        // Nor here!
                        ncms = ncms.Where(e => e.DESCRICAO.ToLower().Contains(searchString.ToLower()));
                        break;
                }
            }
        }
    }
    // This is the important bit - what happens if the request is not an AJAX request?
    else
    {
        ncms = ncms.Take(1000); // eg, limit to first 1000 rows
    }
    return PartialView("BuscarNcm", ncms.ToList()); // finally here we execute the query before going to the View
