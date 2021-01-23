    var query = _cityRepository.GetAll()
               .Select(item => 
                 {
                   var fields = item.ShortTitle.Split('-');
                   return new
                   {
                     Key = item.RowKey.Substring(0,4),
                     Title = fields[0].Trim(),
                     Index = Convert.ToInt16(fields[1])
                   }
                 })
               .OrderBy(item => item.Key)
               .ThenBy(item => item.Title)
               .ThenBy(item => item.Index);
