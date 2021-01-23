     string temp = SearchedQuery.Trim();
     DateTime res;
     if (DateTime.TryParse(temp, out res))
     {
     query += ((" ( it." + field.Name + " >@p" + i + ""));
     query += " AND ";
     ObjectParameter pr = new ObjectParameter("p" + i, res);
     i++;
     query += ((" it." + field.Name + " <@p" + i + " ) "));
     ObjectParameter pr1 = new ObjectParameter("p" + i, res.AddDays(1));
     param.Add(pr);
     param.Add(pr1);
     query += " OR ";
    }
